using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    [SerializeField]
    private Runner runner;
    private Animation animationPlayer;

    void Start()
    {
        animationPlayer = gameObject.GetComponent<Animation>();
    }

    public void Jump()
    {
        animationPlayer.Play("JumpAnimation");
    }

    public void AnimationFinished()
    {
        runner.JumpFinished();
    }
}
