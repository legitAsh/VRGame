using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingArmMovement : MonoBehaviour {
	public GameObject leftHand;
	public GameObject rightHand;
	public GameObject CenterEyeCamera;
	public GameObject forwardDirection;

	Vector3 positionPreviousFrameLeftHand;
	Vector3 positionPreviousFrameRightHand;
	Vector3 playerPositionPreviousFrame;
	Vector3 playerPositionCurrentFrame;
	Vector3 positionCurrentFrameLeftHand;
	Vector3 positionCurrentFrameRightHand;

	public float speed = 70;
	float handSpeed;

	void Start() {
		// Set original previous frame positions at start up
		playerPositionPreviousFrame = transform.position;
		positionPreviousFrameLeftHand = leftHand.transform.position;
		positionPreviousFrameRightHand = rightHand.transform.position;
	}

	void Update() {
		// Get forward direction from center eye camera and set it to forward direction object
		float yRotation = CenterEyeCamera.transform.eulerAngles.y;
		forwardDirection.transform.eulerAngles = new Vector3(0, yRotation, 0);

		// Get current positions off hands
		positionCurrentFrameLeftHand = leftHand.transform.position;
		positionCurrentFrameRightHand = rightHand.transform.position;
		// Position off player
		playerPositionCurrentFrame = transform.position;

		// Get distance hands and player has moved since last frame
		float playerDistanceMoved = Vector3.Distance(playerPositionCurrentFrame, playerPositionPreviousFrame);
		float leftHandDistanceMoved = Vector3.Distance(positionPreviousFrameLeftHand, positionCurrentFrameLeftHand);
		float rightHandDistanceMoved = Vector3.Distance(positionPreviousFrameRightHand, positionCurrentFrameRightHand);

		handSpeed = ((leftHandDistanceMoved - playerDistanceMoved) + (rightHandDistanceMoved - playerDistanceMoved));

		if (Time.timeSinceLevelLoad > 1f)
			transform.position += forwardDirection.transform.forward * handSpeed * speed * Time.deltaTime;

		// Set previous positions of hands for next frame
		positionPreviousFrameLeftHand = positionCurrentFrameLeftHand;
		positionPreviousFrameRightHand = positionCurrentFrameRightHand;

		// Set player position previous frame
		playerPositionPreviousFrame = playerPositionCurrentFrame;
	}
}