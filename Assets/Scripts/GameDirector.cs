﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Vider la liste des modules actifs au fur et à mesure et checker lorsqu'elle est vide

public class GameDirector : MonoBehaviour
{
    [SerializeField]
    private int difficulty = 0;

    [SerializeField]
    private float baseDuration = 5f;

    [SerializeField]
    private MeshRenderer startText;

    [SerializeField]
    private MeshRenderer gameOverText;

    private List<string> moduleNamesOrder;
    private List<Module> moduleList = new List<Module>();
    private List<Module> enabledModuleList = new List<Module>();
    private List<Module> activatedModuleList = new List<Module>();
    private JumpButton jumpButton;
    private Runner runner;
    private float runDuration = 5f;
    private bool gameStarted = false;

    void Start()
    {
        moduleNamesOrder = new List<string>(){
            "GreenButton",
            "LeverModule",
            "Matemathic",
            "WindUp",
            "ClickMe",
            "ShortCut",
            "Simon"
        };

        foreach (string moduleName in moduleNamesOrder)
        {
            moduleList.Add(GameObject.Find(moduleName).GetComponent<Module>());
        }

        jumpButton = FindObjectOfType<JumpButton>();
        runner = FindObjectOfType<Runner>();

        gameOverText.enabled = false;
        runner.SetRunnerVisibility(false);
        EnableJumpButton();
    }

    public void JumpButtonClicked()
    {
        Debug.Log("click");
        if (!gameStarted)
        {
            startText.enabled = false;
            gameOverText.enabled = false;
            runDuration = GenerateTable();
            runner.SetRunnerVisibility(true);
            runner.StartRun(runDuration);
            DisableJumpButton();
            EnableJumpButton();
            gameStarted = true;
            return;
        }

        DestroyTable();
        runner.Jump();
    }

    public void RunnerJumped()
    {
        difficulty += 1;
        runDuration = GenerateTable();
        DisableJumpButton();
        runner.StartRun(runDuration);
    }

    public void ModuleActivated(Module module)
    {
        activatedModuleList.Remove(module);

        if (activatedModuleList.Count == 0) EnableJumpButton();
    }

    private void EnableJumpButton()
    {
        jumpButton.SetButtonState(true);
    }

    private void DisableJumpButton()
    {
        jumpButton.SetButtonState(false);
    }

    private float GenerateTable()
    {
        float tempRunDuration = 0f;

        for (int i = 0; i < difficulty; i++)
        {
            if (!(i < moduleList.Count)) break;

            // Debug.Log(i);
            enabledModuleList.Add(moduleList[i]);
            activatedModuleList.Add(moduleList[i]);
        }

        foreach (Module module in enabledModuleList)
        {
            // Debug.Log(enabledModuleList.Count);
            module.Enable();
            tempRunDuration += module.execTime;
        }

        return tempRunDuration + baseDuration;
    }

    private void DestroyTable()
    {
        // Debug.Log(enabledModuleList.Count);
        foreach (Module module in enabledModuleList)
        {
            // Debug.Log(module);
            module.Disable();
        }
        enabledModuleList.Clear();
        activatedModuleList.Clear();
    }

    public void GameOver()
    {
        DestroyTable();
        DisableJumpButton();
        EnableJumpButton();
        runner.SetRunnerVisibility(false);
        gameOverText.enabled = true;
        gameStarted = false;
        difficulty = 0;
    }



}
