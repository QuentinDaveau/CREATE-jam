using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{

    [SerializeField]
    private GameObject runner;

    [SerializeField]
    private GameObject wall;

    private float timer;
    private float stepTimer;
    private float tempTimer;
    private int steps = 10;
    private float totalDistance;
    private float stepDistance;

    void Start()
    {
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
        timer = duration;
        stepTimer = duration / steps;
        tempTimer = timer - stepTimer;
        Debug.Log(stepTimer);
    }

    private void Timer()
    {
        timer -= Time.deltaTime;
        if (timer <= 0) return;
        if (timer <= tempTimer)
        {
            tempTimer -= stepTimer;
            Debug.Log(tempTimer);
            Run();
        }
    }

    private void Run()
    {
        runner.transform.position = new Vector3(runner.transform.position.x + stepDistance, 0f, 0f);
    }

    /*public void StartRun(float duration)
    {
        if (duration == 0f) return;
        runner.transform.position = startPosition;
        Debug.Log("Starting run for " + duration + " seconds !");
        distance = Vector3.Distance(runner.transform.position, wall.transform.position);
        speed = distance / duration;
        return;
    }

    private void Run()
    {
        if (distance == 0f)
        {
            death = true;
            Debug.Log("DEAD GUY");
            runner.transform.Translate(0f, 0f, 0f);
        }
        else {
            runner.transform.Translate(Vector3.right * speed * Time.deltaTime);
            distance = Vector3.Distance(runner.transform.position, wall.transform.position); ;
        }
        Debug.LogWarning(distance);
        return;
    }*/
}
