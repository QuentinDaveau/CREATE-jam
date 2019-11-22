using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    public void Jump() {  Debug.Log("Jump !");}
    public void StartRun(float duration) { Debug.Log("Starting run for " + duration + " seconds !");}
}
