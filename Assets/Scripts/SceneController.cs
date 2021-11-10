using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    private GameObject rig;
    [SerializeField]
    private GameObject transitionPoint;
    [SerializeField]
    private float transitionDistance = 1f;

    private bool readyForTransition = false;

    void Update()
    {
        if (readyForTransition && Vector3.Distance(rig.transform.position, transitionPoint.transform.position) < transitionDistance)
        {
            SceneManager.LoadScene("Ending", LoadSceneMode.Single);
		}
    }

    public void ActivateTransition()
    {
        readyForTransition = true;
	}
}
