using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenButton : Module
{
    public void ResetDone()
    {
        base.Enable();
    }
    public override void Enable()
    {
        animationPlayer.Play("GreenButtonReset");
    }

    public override void PointerClick()
    {
        animationPlayer.Play("GreenButtonClicked");
        Activated();
    }
}
