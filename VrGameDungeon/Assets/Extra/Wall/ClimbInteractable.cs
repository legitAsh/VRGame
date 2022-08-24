using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ClimbInteractable : XRBaseInteractable {
	protected override void OnSelectEntered(XRBaseInteractor interactor) {
		base.OnSelectEntered(interactor);
		//Debug.Log("Select Entered");

		if(interactor is XRDirectInteractor)
			ClimbProvider.climbingHand = interactor.GetComponent<XRController>();
	}

	protected override void OnSelectExited(XRBaseInteractor interactor) {
		base.OnSelectExited(interactor);
		//Debug.Log("Select Exited");

		if(interactor is XRDirectInteractor) {
			if(ClimbProvider.climbingHand && ClimbProvider.climbingHand.name == interactor.name) {
				ClimbProvider.climbingHand = null;
			}
		}
	}
}