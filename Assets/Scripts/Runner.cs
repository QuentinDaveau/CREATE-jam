using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{

    [SerializeField]
    private GameObject runner;

    [SerializeField]
    private GameObject wall;

    [SerializeField]
    private GameDirector gameDirector;

    private float timer;
    private float stepTimer;
    private float tempTimer;
    private float totalDistance;
    private float stepDistance;
    private int steps = 10;
    private Vector3 initRunner;

    void Start()
    {
        initRunner = runner.transform.position;
        totalDistance = Vector3.Distance(runner.transform.position, wall.transform.position);
        stepDistance = totalDistance / steps;
    }

    void Update()
    {
        Timer();
    }

    public void Jump() { Debug.Log("Jump !"); }
    public void StartRun(float duration)
    {
        Debug.Log("Starting run for " + duration + " seconds !");
        runner.transform.position = initRunner;
        timer = duration;
        stepTimer = duration / steps;
        tempTimer = timer - stepTimer;
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
        runner.transform.position = new Vector3(runner.transform.position.x + stepDistance, runner.transform.position.y, runner.transform.position.z);
    }

    private void Death()
    {
        gameDirector.GameOver();
    }
}
