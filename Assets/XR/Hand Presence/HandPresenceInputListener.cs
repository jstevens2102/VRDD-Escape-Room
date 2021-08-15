using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandPresenceInputListener : MonoBehaviour
{
    [SerializeField]
    private InputActionReference triggerInputAction, gripInputAction;
    
    private Animator animationController;
    private InputAction triggerAction, gripAction;

    // Start is called before the first frame update
    void Start()
    {
        animationController = GetComponent<Animator>();
        triggerAction = triggerInputAction.ToInputAction();
        gripAction = gripInputAction.ToInputAction();
    }

    // Update is called once per frame
    void Update()
    {
        animationController.SetFloat("Trigger", triggerAction.ReadValue<float>());
        animationController.SetFloat("Grip",gripAction.ReadValue<float>());
    }
}
