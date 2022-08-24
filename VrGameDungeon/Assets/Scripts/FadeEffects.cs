using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class FadeEffects : MonoBehaviour {
	TMP_Text text;
	public float duration = 2.0f;
	
	void Awake() {
		text = GetComponent<TMP_Text>();
		text.color = Color.clear;
	}

	public void FadeInAlpha() {
			text.color = Color.Lerp(text.color, Color.white, duration);
	}

	public void FadeOutAlpha() {
			text.color = Color.Lerp(text.color, Color.clear, duration);
	}
}