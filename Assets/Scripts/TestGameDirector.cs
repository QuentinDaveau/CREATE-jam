﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGameDirector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            FindObjectOfType<GameDirector>().JumpButtonClicked();
        }

        if(Input.GetButtonDown("Fire1"))
        {
            FindObjectOfType<GameDirector>().RunnerJumped();
        }
    }
}