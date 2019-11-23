using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShortCut : Module
{
    [SerializeField]
    private Text displayText;

    [SerializeField]
    private Text buttonsText;

    private string letters = "abcdefghijklmnopqrstuvwxyz";
    private List<int> keyCodes = new List<int>();
    private bool isEnabled = false;
    private bool[] keyPressed = new bool[4];

    public override void Enable()
    {
        displayText.text = "press shortcut:";
        keyCodes.Clear();
        GenerateShortcut();
        base.Enable();
    }

    private void GenerateShortcut()
    {
        List<int> alreadyUsed = new List<int>();
        string displayedValue = "";

        for(int i = 0; i < 4; i++)
        {
            int random = Random.Range(0, letters.Length);
            while(alreadyUsed.Contains(random))
            {
                random = Random.Range(0, letters.Length);
            }
            keyCodes.Add(random);
            string c = letters[random].ToString();
            displayedValue += c;
            alreadyUsed.Add(random);
            if(i < 3) displayedValue += " + ";
        }

        buttonsText.text = displayedValue;
        isEnabled = true;

        for(int i = 0; i< keyPressed.Length; i++)
        {
            keyPressed[i] = false;
        }
    }

    void Update()
    {
        if (!isEnabled) return;

        if(Input.GetKeyDown((KeyCode)(97 + keyCodes[0])))
        {
            keyPressed[0] = true;
        }
        if(Input.GetKeyUp((KeyCode)(97 + keyCodes[0])))
        {
            keyPressed[0] = false;
        }

        if(Input.GetKeyDown((KeyCode)(97 + keyCodes[1])))
        {
            keyPressed[1] = true;
        }
        if(Input.GetKeyUp((KeyCode)(97 + keyCodes[1])))
        {
            keyPressed[1] = false;
        }

        if(Input.GetKeyDown((KeyCode)(97 + keyCodes[2])))
        {
            keyPressed[2] = true;
        }
        if(Input.GetKeyUp((KeyCode)(97 + keyCodes[2])))
        {
            keyPressed[2] = false;
        }

        if(Input.GetKeyDown((KeyCode)(97 + keyCodes[3])))
        {
            keyPressed[3] = true;
        }
        if(Input.GetKeyUp((KeyCode)(97 + keyCodes[3])))
        {
            keyPressed[3] = false;
        }

        // Debug.Log(keyPressed[0]+"   "+keyPressed[1]+"   "+keyPressed[2]+"   "+keyPressed[3]);

        bool allGood = true;
        foreach(bool value in keyPressed)
        {
            if (value == false) allGood = false;
        }

        if(allGood) GoodShortcut();
    }

    private void GoodShortcut()
    {
        isEnabled = false;
        displayText.text = "Good Job !";
        buttonsText.text = "YAY !";
        Activated();
    }
}
