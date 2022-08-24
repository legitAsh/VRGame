using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityControl : MonoBehaviour {
	CharacterController characterController;
	bool climbing = false;

	void Start() {
		characterController = GetComponent<CharacterController>();
		ClimbProvider.ClimbActive += ClimbActive;
		ClimbProvider.ClimbInactive += ClimbInactive;
	}

	void OnDestroy() {
		ClimbProvider.ClimbActive -= ClimbActive;
		ClimbProvider.ClimbInactive -= ClimbInactive;
	}

	void FixedUpdate() {
		if(!characterController.isGrounded && !climbing) {
			characterController.SimpleMove(new Vector3());
		}
	}

	void ClimbActive() {
		climbing = true;
	}

	void ClimbInactive() {
		climbing = false;
	}
}