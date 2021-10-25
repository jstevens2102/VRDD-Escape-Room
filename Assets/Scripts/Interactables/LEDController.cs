using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LEDController : MonoBehaviour
{
    // editor parameters
    [SerializeField]
    private Material ledOnMaterial;
    [SerializeField]
    private Material ledOffMaterial;
    [SerializeField]
    private GameObject led1, led2, led3;
    [SerializeField]
    private bool debug = false;

    // internal variables
    private bool led1state = false, led2state = false, led3state = false;
    private bool ledComplete = false;

    private MeshRenderer led1rend, led2rend, led3rend;

    public UnityEvent LEDPuzzleCompleted;

    // Start is called before the first frame update
    void Start()
    {
        led1rend = led1.GetComponent<MeshRenderer>();
        led2rend = led2.GetComponent<MeshRenderer>();
        led3rend = led3.GetComponent<MeshRenderer>();

        led1rend.material = ledOffMaterial;
        led2rend.material = ledOffMaterial;
        led3rend.material = ledOffMaterial;
    }

    void CheckCompletion()
    {
        if (led1state && led2state && led3state)
        {
            ledComplete = true;
            if (debug) Debug.Log("All LEDs complete!");
            LEDPuzzleCompleted.Invoke();
        }
    }

    public bool IsLEDComplete()
    {
        return ledComplete;
    }

    public void CompleteLED1()
    {
        led1rend.material = ledOnMaterial;
        led1state = true;

        if (debug) Debug.Log("LED 1 completed!");

        CheckCompletion();
    }

    public void CompleteLED2()
    {
        led2rend.material = ledOnMaterial;
        led2state = true;

        if (debug) Debug.Log("LED 2 completed!");

        CheckCompletion();
    }

    public void CompleteLED3()
    {
        led3rend.material = ledOnMaterial;
        led3state = true;

        if (debug) Debug.Log("LED 3 completed!");

        CheckCompletion();
    }
}
