using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField]
    private Light[] lights;
    [SerializeField]
    private AudioClip onSound, offSound;

    private bool lightsOn = true;
    private AudioSource audioEmitter;

	public void Start() {
        audioEmitter = GetComponent<AudioSource>();
	}

	public void ToggleLights()
    {
        if (lightsOn)
        {
            foreach (Light lightEmitter in lights)
            {
                lightEmitter.enabled = false;
                audioEmitter.PlayOneShot(offSound);
			}
            lightsOn = false;
		}
        else
        {
            foreach (Light lightEmitter in lights)
            {
                lightEmitter.enabled = true;
                audioEmitter.PlayOneShot(onSound);
            }
            lightsOn = true;
        }
	}
}
