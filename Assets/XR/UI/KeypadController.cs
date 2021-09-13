using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class KeypadController : MonoBehaviour
{
    [SerializeField]
    private string requiredCode;

    [SerializeField]
    private Button[] buttonList;

    [SerializeField]
    private TextMeshProUGUI codeDisplayText;

    [SerializeField]
    private bool debugEnabled;

    private bool keypadState = false; // current unlocked state of keypad
    private bool canInteract = true; // true = buttons can be pressed, false = input is ignored

    public UnityEvent keypadUnlocked;

    bool IsUnlocked() // is the keypad unlocked
    {
        return keypadState;
    }

    void ResetKeypad()
    {
        keypadState = false;
        codeDisplayText.text = "";
    }

    // Start is called before the first frame update
    void Start()
    {
        if (buttonList.Length < 12)
        {
            Debug.LogError("Keypad script: Missing button references detected");
        }

        buttonList[0].onClick.AddListener(delegate { KeypadButtonPressed(1); });
        buttonList[1].onClick.AddListener(delegate { KeypadButtonPressed(2); });
        buttonList[2].onClick.AddListener(delegate { KeypadButtonPressed(3); });
        buttonList[3].onClick.AddListener(delegate { KeypadButtonPressed(4); });
        buttonList[4].onClick.AddListener(delegate { KeypadButtonPressed(5); });
        buttonList[5].onClick.AddListener(delegate { KeypadButtonPressed(6); });
        buttonList[6].onClick.AddListener(delegate { KeypadButtonPressed(7); });
        buttonList[7].onClick.AddListener(delegate { KeypadButtonPressed(8); });
        buttonList[8].onClick.AddListener(delegate { KeypadButtonPressed(9); });
        buttonList[9].onClick.AddListener(delegate { KeypadButtonPressed(10); });
        buttonList[10].onClick.AddListener(delegate { KeypadButtonPressed(11); });
        buttonList[11].onClick.AddListener(delegate { KeypadButtonPressed(12); });
    }

    // Adds a digit to the current keypad code
    void AddDigit(int c)
    {
        if (codeDisplayText.text.Length < requiredCode.Length) codeDisplayText.text += c.ToString();
        else
        {
            // play some kind of error sound
        }
    }

    // Clears all digits from the keypad code
    void ClearCode()
    {
        codeDisplayText.text = "";
    }

    // Checks if the code is valid and updates the keypad state if correct
    void CheckCode()
    {
        if (codeDisplayText.text == requiredCode)
        {
            keypadState = true;
            canInteract = false;
            // play success sound
            if (debugEnabled) Debug.Log("Keypad successfully unlocked!");
            keypadUnlocked.Invoke();
        }
        else
        {
            ClearCode();
            // play failure sound
            if (debugEnabled) Debug.Log("Keypad failed to unlock!");

        }
    }

    // Function called when a button is pressed on the UI
    // buttonID:
    // 1-9 = digits 1-9
    // 10 = 0
    // 11 = CLR
    // 12 = ENT
    void KeypadButtonPressed(int buttonID)
    {
        if (canInteract)
        {
            if (debugEnabled) Debug.Log("Button with ID: " + buttonID + " was pressed");
            switch (buttonID)
            {
                case int n when (n > 0 && n <= 9):
                    AddDigit(buttonID);
                    break;
                case 10:
                    AddDigit(0);
                    break;
                case 11:
                    ClearCode();
                    break;
                case 12:
                    CheckCode();
                    break;
            }
        }
    }
}
