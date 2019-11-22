using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module : MonoBehaviour
{
    public float execTime = 5f;
    public void Enable() { Debug.Log("Module "+ gameObject.name + " enabled !");}
    public void Disable() { Debug.Log("Module "+ gameObject.name + " disabled !");}
}
