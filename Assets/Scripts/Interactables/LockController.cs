using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LockController : MonoBehaviour
{
    // editor paramaters
    [SerializeField]
    private GameObject key;
    [SerializeField]
    private GameObject keyPosition;
    [SerializeField]
    private float completionDistance = 0.2f;
    [SerializeField]
    private bool debug = false;

    // internal variables
    private bool unlockedState = false;
    private XROffsetGrabInteractable keyGrabInteractable;

    public UnityEvent KeyInserted;

    private void Start()
    {
        keyGrabInteractable = key.GetComponent<XROffsetGrabInteractable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(keyPosition.transform.position, key.transform.position) <= completionDistance && keyGrabInteractable.isSelected && !unlockedState)
        {
            unlockedState = true;
            KeyInserted.Invoke();
            HandleKeyInsertion();
            if (debug) Debug.Log("Key inserted!");
        }
    }

    public bool GetUnlockedState()
    {
        return unlockedState;
	}

    private void HandleKeyInsertion()
    {
        key.transform.position = keyPosition.transform.position;
        key.transform.rotation = keyPosition.transform.rotation;
        keyGrabInteractable.enabled = false;
        key.GetComponent<Collider>().enabled = false;
        key.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
	}


}
