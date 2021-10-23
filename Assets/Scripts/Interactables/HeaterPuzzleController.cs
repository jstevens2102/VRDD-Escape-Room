using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HeaterPuzzleController : MonoBehaviour
{
    // editor parameters
    [SerializeField]
    private ValveController[] valves;
    [SerializeField]
    private bool debug = false;

    // internal variables
    private bool puzzleCompleted = false;

    public UnityEvent PuzzleCompleted;

    // Update is called once per frame
    void Update()
    {
        if (!puzzleCompleted && valvesInPosition())
        {
            CompletePuzzle();
        }
    }

    public bool valvesInPosition()
    {
        int i = 0;
        int correctValves = 0;
        foreach (ValveController valve in valves)
        {
            bool valveCorrect = valve.IsInCorrectPosition();
            if (debug) Debug.Log("Valve " + i + " position: " + valveCorrect);
            if (valveCorrect) correctValves++;
            i++;
        }
        return (correctValves == valves.Length);
    }

    void CompletePuzzle()
    {
        puzzleCompleted = true;
        if (debug) Debug.Log("Puzzle complete");

        foreach (ValveController valve in valves)
        {
            valve.gameObject.GetComponent<Rigidbody>().freezeRotation = true;
            valve.gameObject.GetComponent<XROffsetGrabInteractable>().enabled = false;
        }

        PuzzleCompleted.Invoke();
    }

    public bool IsComplete()
    {
        return puzzleCompleted;
    }

    
    
}
