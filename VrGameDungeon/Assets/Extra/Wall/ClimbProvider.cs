using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using System;

public class ClimbProvider : MonoBehaviour {
	public GameObject character;
	CharacterController characterController;
	public static XRController climbingHand;
	DeviceBasedContinuousMoveProvider continuousMovement;

	public static event Action ClimbActive;
	public static event Action ClimbInactive;

	void Start() {
		characterController = character.GetComponent<CharacterController>();
		continuousMovement = GetComponent<DeviceBasedContinuousMoveProvider>();
	}

	void FixedUpdate() {
		if(climbingHand) {
			continuousMovement.enabled = false;
			ClimbActive?.Invoke();
			Climb();
		} else {
			continuousMovement.enabled = true;
			ClimbInactive?.Invoke();
		}
	}

	void Climb() {
		InputDevices.GetDeviceAtXRNode(climbingHand.controllerNode).TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 velocity);
		Debug.Log(velocity);

		characterController.Move(-velocity * Time.fixedDeltaTime);
	}
}