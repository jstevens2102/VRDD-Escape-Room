using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TornLabelController : MonoBehaviour
{
    // editor parameters
    [SerializeField]
    private GameObject label, tornLabel;
    [SerializeField]
    private Material completedLabelMaterial;
    [SerializeField]
    private float completionDistance = 0.2f;
    [SerializeField]
    private bool debug;

    // internal variables
    bool labelAttached = false;

    public UnityEvent LabelAttached;

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(label.transform.position, tornLabel.transform.position) <= completionDistance && !labelAttached)
        {
            AttachLabel();
		}
    }

    public bool IsLabelAttached()
    {
        return labelAttached;
	}

    private void AttachLabel()
    {
        tornLabel.SetActive(false);
        label.GetComponent<MeshRenderer>().material = completedLabelMaterial;
        LabelAttached.Invoke();
        if (debug) Debug.Log("Label attached!");
	}
}
