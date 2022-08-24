using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportationManager : MonoBehaviour {
	[SerializeField] InputActionAsset actionAsset;
	[SerializeField] XRRayInteractor rayInteractor;
	[SerializeField] TeleportationProvider provider;
	InputAction thumbstick;
	bool isActive;

	void Start() {
		rayInteractor.enabled = false;

		var activate = actionAsset.FindActionMap("XRI LeftHand Locomotion").FindAction("Teleport Mode Activate");
		activate.Enable();
		activate.performed += OnTeleportActivate;

		var cancel = actionAsset.FindActionMap("XRI LeftHand Locomotion").FindAction("Teleport Mode Cancel");
		cancel.Enable();
		cancel.performed += OnTeleportCancel;

		thumbstick = actionAsset.FindActionMap("XRI LeftHand Locomotion").FindAction("Move");
		thumbstick.Enable();
	}

	void Update() {
		if(!isActive)
			return;

		if(thumbstick.triggered)
			return;

		if(!rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit)) {
			rayInteractor.enabled = false;
			isActive = false;
			return;
		}

		TeleportRequest request = new TeleportRequest() {
			destinationPosition = hit.point,
			//destinationRotation = ;
			//matchOrientation = ;
			//requestTime = ;
		};

		provider.QueueTeleportRequest(request);
	}

	void OnTeleportActivate(InputAction.CallbackContext context) {
		rayInteractor.enabled = true;
		isActive = true;
	}

	void OnTeleportCancel(InputAction.CallbackContext context) {
		rayInteractor.enabled = false;
		isActive = false;
	}
}