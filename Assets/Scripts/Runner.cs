using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{

    [SerializeField]
    private GameObject runner;

    [SerializeField]
    private MeshRenderer runnerModel1;

    [SerializeField]
    private MeshRenderer runnerModel2;

    [SerializeField]
    private MeshRenderer wallMesh;

    [SerializeField]
    private GameObject wall;

    [SerializeField]
    private GameDirector gameDirector;

    [SerializeField]
    private WallManager wallManager;

    private float timer;
    private float stepTimer;
    private float tempTimer;
    private float totalDistance;
    private float stepDistance;
    private int steps = 10;
    private Vector3 initRunner;
    private bool run;

    void Start()
    {
        initRunner = runner.transform.localPosition;
        totalDistance = Vector3.Distance(runner.transform.localPosition, wall.transform.localPosition);
        stepDistance = totalDistance / steps;
    }

    void Update()
    {
        if(!run) return;
        Timer();
    }

    public void Jump() 
    {
        run = false;
        wallManager.Jump();
    }

    public void StartRun(float duration)
    {
        run = true;
        Debug.Log("Starting run for " + duration + " seconds !");
        runner.transform.localPosition = initRunner;
        timer = duration;
        stepTimer = duration / steps;
        tempTimer = timer - stepTimer;
    }

    public void SetRunnerVisibility(bool visibility)
    {
        runnerModel1.enabled = visibility;
        runnerModel2.enabled = visibility;
        wallMesh.enabled = visibility;
    }

    public void JumpFinished()
    {
        gameDirector.RunnerJumped();
    }

    private void Timer()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Death();
            return;
        }
        if (timer <= tempTimer)
        {
            tempTimer -= stepTimer;
            Run();
        }
    }

    private void Run()
    {
        runner.transform.localPosition = new Vector3(runner.transform.localPosition.x - stepDistance, runner.transform.localPosition.y, runner.transform.localPosition.z);
    }

    private void Death()
    {
        gameDirector.GameOver();
        run = false;
    }
}
