using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    public bool useControllerModel = false;
    public InputDeviceCharacteristics controllerCharacteristics;
    public List<GameObject> controllerPrefabs;
    public GameObject handModelPrefab;

    private InputDevice targetDevice;
    private GameObject controllerInstance;
    private GameObject handInstance;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Test");    

        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        foreach (var item in devices) {
            Debug.Log(item.name + item.characteristics);
		}

        if (devices.Count > 0) {
            targetDevice = devices[0];
           
            GameObject prefab = controllerPrefabs.Find(controller => controller.name == targetDevice.name);
            if (prefab) {
                controllerInstance = Instantiate(prefab, transform);
			} else {
                Debug.LogError("Did not find matching controller for device " + targetDevice.name);
                controllerInstance = Instantiate(controllerPrefabs[0], transform);
			}

            //handInstance = Instantiate(handModelPrefab, transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        /* INPUT DEBUGGING
            if (targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue) && primaryButtonValue)
            Debug.Log("Pressed primary button on device " + targetDevice.name);

        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) && triggerValue > 0.1f) 
            Debug.Log("Trigger pressed on device " + targetDevice.name + ": " + triggerValue);

        if (targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue) && primary2DAxisValue != Vector2.zero)
            Debug.Log("Primary 2d axis input for " + targetDevice.name + ": " + primary2DAxisValue);
        */

        if (useControllerModel) {
            //handInstance.SetActive(false);
            controllerInstance.SetActive(true);
		} else {
            //handInstance.SetActive(true);
            controllerInstance.SetActive(false);
		}
    }
}
