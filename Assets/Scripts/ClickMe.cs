using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMe : Module
{
    [SerializeField]
    private float minDuration = 6f;

    [SerializeField]
    private float maxDuration = 10f;

    private bool clickMe = false;
    private bool pressed = false;

    private Coroutine waitForBlink;



    public void EnabledDone()
    {
        base.Enable();
        waitForBlink = StartCoroutine(WaitBetweenBlink());
    }

    public override void Enable()
    {
        animationPlayer.Play("ClickEnable");
    }

    public void BlinkFinished()
    {
        clickMe = false;
        waitForBlink = StartCoroutine(WaitBetweenBlink());
    }

    public override void PointerClick()
    {
        animationPlayer.Play("ClickDisable");
        if(pressed) return;
        if (!clickMe) return;

        animationPlayer.Play("ClickPress");

        StopAllCoroutines();
        Activated();
    }

    private IEnumerator WaitBetweenBlink()
    {
        yield return new WaitForSeconds(Random.Range(minDuration, maxDuration));
        clickMe = true;
        animationPlayer.Play("ClickBlink");
    }
}
