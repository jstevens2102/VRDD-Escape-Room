using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRSocketListener : MonoBehaviour
{
    private XRBaseInteractor socketInteractor;

    // Start is called before the first frame update
    void Start()
    {
        socketInteractor = GetComponent<XRBaseInteractor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (socketInteractor.selectTarget != null)
        {
            Debug.Log(socketInteractor.selectTarget.name);
        }
    }
}
