using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GramophoneController : MonoBehaviour
{
	[SerializeField]
	private float rotationSpeed = 1f;
	[SerializeField]
	private GameObject gramoHandle;

	private AudioSource audioEmitter;
	private bool isPlaying = false;

	public void Start() {
		audioEmitter = GetComponent<AudioSource>();
	}

	public void Update() {
		if (isPlaying)
		{
			gramoHandle.transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0), Space.Self);
		}
	}

	public void PlayGramophone()
	{
		if (!isPlaying) {
			audioEmitter.Play();
			isPlaying = true;
			StartCoroutine(WaitUntilFinished());
		}
	}

	IEnumerator WaitUntilFinished()
	{
		yield return new WaitForSeconds(audioEmitter.clip.length);
		isPlaying = false;
	}
}
