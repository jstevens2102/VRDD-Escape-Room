using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValveController : MonoBehaviour
{
    // editor parameters
    [SerializeField]
    private GameObject displayCylinder;
    [SerializeField]
    private GameObject displayLight;
    [SerializeField]
    private Material lightOnMaterial, lightOffMaterial;
    [SerializeField]
    private Transform startPosition, endPosition;
    [SerializeField]
    private float correctPosition, tolerance;
    [SerializeField]
    private bool debug = false;

    // internal variables
    private HingeJoint hinge;
    private MeshRenderer lightRenderer;
    private float currentPosition;
    private float lastFramePosition = 0;
    private bool lastFrameCorrect = false;
    private bool lightOn = false;

    // Start is called before the first frame update
    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        lightRenderer = displayLight.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lastFramePosition = currentPosition;
        currentPosition = Mathf.InverseLerp(hinge.limits.min, hinge.limits.max, hinge.angle);
        
        displayCylinder.transform.position = Vector3.Lerp(startPosition.position, endPosition.position, currentPosition);

        if (IsInCorrectPosition() && !lightOn)
        {
            lightRenderer.material = lightOnMaterial;
            lightOn = true;
        }
            
        if ((!IsInCorrectPosition()) && lightOn)
        {
            lightRenderer.material = lightOffMaterial;
            lightOn = false;
        }
            

        // only show currentPosition && correct state if it has updated since last frame
        if (debug)
        {
            if (lastFramePosition != currentPosition) Debug.Log("currentPosition: " + currentPosition);
            bool correct = IsInCorrectPosition();
            if (correct != lastFrameCorrect) {
                if (correct == true) Debug.Log("Cylinder entered correct position!");
                else Debug.Log("Cylinder exited correct position!");
                lastFrameCorrect = correct;
            }
        }
    }

    public bool IsInCorrectPosition()
    {
        if (Mathf.Abs(correctPosition - currentPosition) <= tolerance) return true;
        else return false;
	}
}
