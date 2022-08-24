using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketWithTagCheck : XRSocketInteractor {
	public string targetTag = string.Empty;

	//public override bool CanHover(IXRHoverInteractable interactable) {
	//	return base.CanHover(interactable) && MatchUsingTag(interactable);
	//}

	//public override bool CanSelect(IXRSelectInteractable interactable) {
	//	return base.CanSelect(interactable) && MatchUsingTag(interactable);
	//}

	//bool MatchUsingTag(XRBaseInteractable interactable) {
	//	return interactable.CompareTag(targetTag);
	//}
}