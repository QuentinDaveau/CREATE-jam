using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpButton : MonoBehaviour
{
    private bool isEnabled = false;
    private bool isJumping = false;
    private Animation animationPlayer;

    void Start()
    {
        animationPlayer = gameObject.GetComponent<Animation>();
    }

    public void SetButtonState(bool enable)
    {
        isEnabled = enable;
        // Debug.Log(isEnabled);

        if (isEnabled)
        {
            Enable();
        }
        else
        {
            Disable();
            isJumping = false;
        }
    }

    void OnMouseUpAsButton()
    {
        if (!isEnabled) return;
        animationPlayer.Play("JumpButtonClicked");
        if(isJumping) return;

        isJumping = true;
        FindObjectOfType<GameDirector>().JumpButtonClicked();
    }

    private void Enable()
    {
        animationPlayer.Play("JumpButtonEnable");
    }

    private void Disable()
    {
        animationPlayer.Play("JumpButtonDisable");
    }
}
