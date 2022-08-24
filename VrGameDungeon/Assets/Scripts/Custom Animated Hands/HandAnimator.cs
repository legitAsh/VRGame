using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class HandAnimator : MonoBehaviour {
	public float speed = 5.0f;
	public XRController controller = null;
	//public ActionBasedController controller = null;

	Animator animator = null;

	private readonly List<Finger> gripfingers = new List<Finger>() {
		new Finger(FingerType.Middle),
		new Finger(FingerType.Ring),
		new Finger(FingerType.Pinky)
	};

	private readonly List<Finger> pointFingers = new List<Finger>() {
		new Finger(FingerType.Index),
		new Finger(FingerType.Thumb)
	};

	void Awake() {
		animator = GetComponent<Animator>();
	}

	void Update() {
		// Store input
		CheckGrip();
		CheckPointer();

		// Smooth input values
		SmoothFinger(gripfingers);
		SmoothFinger(pointFingers);

		// Apply smoothed values
		AnimateFinger(gripfingers);
		AnimateFinger(pointFingers);
	}

	void CheckGrip() {
		if(controller.inputDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
			SetFingerTargets(gripfingers, gripValue);
	}

	void CheckPointer() {
		if(controller.inputDevice.TryGetFeatureValue(CommonUsages.trigger, out float pointerValue))
			SetFingerTargets(gripfingers, pointerValue);
	}

	void SetFingerTargets(List<Finger> fingers, float value) {
		foreach(Finger finger in fingers)
			finger.target = value;
	}

	void SmoothFinger(List<Finger> fingers) {
		foreach(Finger finger in fingers) {
			float time = speed * Time.unscaledDeltaTime;
			finger.current = Mathf.MoveTowards(finger.current, finger.target, time);
		}
	}

	void AnimateFinger(List<Finger> fingers) {
		foreach(Finger finger in fingers)
			AnimateFinger(finger.type.ToString(), finger.current);
	}

	void AnimateFinger(string finger, float blend) {
		animator.SetFloat(finger, blend);
	}
}