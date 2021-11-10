using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightController : MonoBehaviour
{
    [SerializeField]
    private AudioClip onSound, offSound;
    
    private Light lightEmitter;
    private AudioSource audioEmitter;

    // Start is called before the first frame update
    void Start()
    {
        lightEmitter = GetComponentInChildren<Light>();
        lightEmitter.enabled = false;
        audioEmitter = GetComponent<AudioSource>();
    }

    public void ToggleLight ()
    {
        if (lightEmitter.enabled)
        {
            lightEmitter.enabled = false;
            audioEmitter.PlayOneShot(offSound);
        }
        else
        {
            lightEmitter.enabled = true;
            audioEmitter.PlayOneShot(onSound);
        }
	}
}
