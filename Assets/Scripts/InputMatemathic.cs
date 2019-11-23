using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class InputMatemathic : Module
{
    [SerializeField]
    private InputField inputMatemathic;

    private int rngInt1, rngInt2, result;
    private string symbol;

    public override void Enable()
    {
        SetOperation();
        SetEmptyField();
        inputMatemathic.interactable = true;
        base.Enable();
    }

    private void SetOperation()
    {
        rngInt1 = UnityEngine.Random.Range(1, 10);
        rngInt2 = UnityEngine.Random.Range(1, 10);
        switch (UnityEngine.Random.Range(1, 4))
        {
            case 1:
                symbol = "+";
                result = rngInt1 + rngInt2;
                break;
            case 2:
                symbol = "-";
                result = rngInt1 - rngInt2;
                break;
            case 3:
                symbol = "x";
                result = rngInt1 * rngInt2;
                break;
            default:
                symbol = "+";
                result = rngInt1 + rngInt2;
                break;
        }
        inputMatemathic.GetComponentInChildren<Text>().text = rngInt1.ToString() + symbol + rngInt2.ToString() + "=?";
    }

    private void SetEmptyField()
    {
        inputMatemathic.text = null;
    }

    public void CheckResult()
    {
        if (Int32.Parse(inputMatemathic.text) != result) return;
        inputMatemathic.interactable = false;
        base.Activated();
    }
}
