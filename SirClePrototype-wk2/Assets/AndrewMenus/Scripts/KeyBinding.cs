using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KeyBinding : MonoBehaviour {

    private KeyboardManager keyboard;
    public Text[] keyLabels;
    private bool shouldChange;
    public KeyboardManager.keyAction remapKey;
	// Use this for initialization
	void Start () {
        if (!keyboard)
        {
            keyboard = GameObject.FindObjectOfType<KeyboardManager>();
        }
        shouldChange = false;
        changeLabel();
	}

    void Update()
    {
        if (shouldChange)
        {
            for (int action = (int)KeyCode.Backspace; action <= (int)KeyCode.Joystick8Button19; action++)
            {
                if (Input.GetKeyDown((KeyCode)action))
                {
                    keyboard.key[(int)remapKey].key = (KeyCode)action;
                    shouldChange = false;
                }
            }
        }
        changeLabel();
    }

    public void Remap(int action)
    {
        remapKey = (KeyboardManager.keyAction)action;
        keyLabels[action].text = "Press New Key";
        shouldChange = true;
    }

    public void changeLabel()
    {
        for (int action = (int)KeyboardManager.keyAction.Forward; action <= (int)KeyboardManager.keyAction.Menu; action++)
        {
            keyLabels[action].text = keyboard.key[action].key.ToString();
        }
    }
}
