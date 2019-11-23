using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestModule : Module
{
    public override void PointerClick()
    {
        Debug.Log("Click!");
        Activated();
    }
}
