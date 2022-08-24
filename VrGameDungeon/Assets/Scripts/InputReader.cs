using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR; // Allow to get input device

public class InputReader : MonoBehaviour {
	//Creating a List of Input Devices to store our Input Devices in
	List<InputDevice> inputDevices = new List<InputDevice>();

	void Start() {
		// Try to Initialize the input reader but all components may not be loaded
		InitializeInputReader();
	}

	// Initialize the input reader by getting all the devices and printing them to the debugger.
	void InitializeInputReader() {
		//InputDevices.GetDevices(inputDevices);
		InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller, inputDevices);

		foreach(var inputDevice in inputDevices) {
			inputDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue);
			Debug.Log(inputDevice.name + " " + triggerValue);

			//Debug.Log(inputDevice.name + " " + inputDevice.characteristics);
		}
	}

	void Update() {
		// Should have a total of 3 input devices
		// If less than 3, then attempt to initialize devices again
		if(inputDevices.Count  < 2) {
			InitializeInputReader();
		}
	}
}