using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightController : MonoBehaviour
{
    private Light lightEmitter;

    // Start is called before the first frame update
    void Start()
    {
        lightEmitter = GetComponentInChildren<Light>();
        lightEmitter.enabled = false;
    }

    public void ToggleLight ()
    {
        if (lightEmitter.enabled)
            lightEmitter.enabled = false;
        else
            lightEmitter.enabled = true;
	}
}
