using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlButton : MonoBehaviour
{
    [SerializeField]
    private int buttonNumber;

    [SerializeField]
    private SimonController simon;

    void OnMouseUpAsButton()
    {
        simon.SyncSimon(buttonNumber);
    }
}
