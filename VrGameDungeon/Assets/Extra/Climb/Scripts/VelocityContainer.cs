using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// Instead of creating a custom controller, we add a simple component to hold the action
/// </summary>
public class VelocityContainer : MonoBehaviour {
    [SerializeField] private InputActionProperty velocityInput;

    public Vector3 Velocity => velocityInput.action.ReadValue<Vector3>();

    //public Vector3 Velocity { get; private set; } = Vector3.zero;
    
    //protected override void UpdateTrackingInput(XRControllerState controllerState) {
    //    base.UpdateTrackingInput(controllerState);
    //    Velocity = velocityAction.action.ReadValue<Vector3>();
    //}
}