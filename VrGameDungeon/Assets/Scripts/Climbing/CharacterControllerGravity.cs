using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerGravity : MonoBehaviour {
	CharacterController _characterController;
	bool _climbing = false;

	void Start() {
		_characterController = GetComponent<CharacterController>();
		Climber.ClimbActive += ClimbActive;
		Climber.ClimbInActive += ClimbInActive;
	}

	void OnDestroy() {
		Climber.ClimbActive -= ClimbActive;
		Climber.ClimbInActive -= ClimbInActive;
	}

	void FixedUpdate() {
		if(!_characterController.isGrounded && !_climbing) {
			_characterController.SimpleMove(new Vector3());
		}
	}

	void ClimbActive() {
		_climbing = true;
	}

	void ClimbInActive() {
		_climbing = false;
	}
}