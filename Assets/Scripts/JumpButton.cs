using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpButton : MonoBehaviour
{
    private bool isEnabled = false;

    public void SetButtonState(bool enable)
    {
        isEnabled = enable;
        Debug.Log(isEnabled);
    }
}
