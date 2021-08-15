using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class XRInputListener : MonoBehaviour
{
    [SerializeField]
    private ActionBasedController leftTeleportRay, rightTeleportRay;

    [SerializeField]
    private InputActionAsset actionAsset;
    private InputActionMap hmdMap, leftControllerMap, rightControllerMap;

    [SerializeField]
    private bool outputDebugMessages = false;

    private InputAction leftSelect, leftActivate, leftTeleport;
    private InputAction rightSelect, rightActivate, rightTeleport;

    void Start()
    {
        // Read action maps from InputAsset
        hmdMap = actionAsset.FindActionMap("XRI HMD", true);
        leftControllerMap = actionAsset.FindActionMap("XRI LeftHand");
        rightControllerMap = actionAsset.FindActionMap("XRI RightHand");

        // Get left actions
        leftSelect = leftControllerMap.FindAction("Select", true);
        leftActivate = leftControllerMap.FindAction("Activate", true);
        leftTeleport = leftControllerMap.FindAction("Teleport Mode Activate", true);

        // Get right actions
        rightSelect = rightControllerMap.FindAction("Select", true);
        rightActivate = rightControllerMap.FindAction("Activate", true);
        rightTeleport = rightControllerMap.FindAction("Teleport Mode Activate", true);
    }

    void Update()
    {
        HandleTeleportVisibility();

        InputDebugMessages();
    }

    // TELEPORTATION HANDLING
    void HandleTeleportVisibility() {
        if (leftTeleportRay) {
            leftTeleportRay.gameObject.SetActive(IsTeleportActive(leftTeleport));
        }
        if (rightTeleportRay) {
            rightTeleportRay.gameObject.SetActive(IsTeleportActive(rightTeleport));
        }
    }
    bool IsTeleportActive(InputAction teleportAction) {
        return (teleportAction.ReadValue<Vector2>() != Vector2.zero);
	}

    // DEBUG
    void InputDebugMessages() {
        if (outputDebugMessages) {
            if (leftSelect.triggered) {
                Debug.Log("Left select activated");
            }

            if (leftActivate.triggered) {
                Debug.Log("Left activate activated");
            }

            if (rightSelect.triggered) {
                Debug.Log("Right select activated");
            }

            if (rightActivate.triggered) {
                Debug.Log("Right activate activated");
            }

            if (rightTeleport.ReadValue<Vector2>() != Vector2.zero) {
                Debug.Log("Right teleport triggered");
            }

            if (leftTeleport.ReadValue<Vector2>() != Vector2.zero) {
                Debug.Log("Left teleport triggered");
            }
        };
    }

    /*void TestFunction(InputAction.CallbackContext context) {
        Debug.Log("Action triggered: " + context);
	}*/

}
