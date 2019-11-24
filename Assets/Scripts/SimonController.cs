using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonController : Module
{
    [SerializeField]
    private Material[] materials;

    [SerializeField]
    private MeshRenderer[] meshRenderer;

    private List<int> simon = new List<int>();
    private List<int> tmpSimon = new List<int>();

    private float timer = 2;
    private int i = 0;
    private bool sequence = false, player = false;

    void Update()
    {
        if (!sequence) return;
        PlaySimon();
    }

    private void SetSimon()
    {
        simon.Add(4);
        simon.Add(3);
        simon.Add(1);
        simon.Add(2);
        tmpSimon = simon;
        foreach (int test in tmpSimon)
        {
            Debug.LogWarning(test);
        }
        sequence = true;
    }

    private void PlaySimon()
    {
        if (simon.Count == 0) return;
        if (i >= simon.Count)
        {
            i = 0;
            sequence = false;
            player = true;
            return;
        }

        int tmp = simon[i];
        timer -= Time.deltaTime;
        if (timer >= 1) meshRenderer[tmp - 1].material = materials[tmp];
        else if (timer >= 0) meshRenderer[tmp - 1].material = materials[0];
        else if (timer < 0)
        {
            timer = 2;
            i++;
        }
    }

    private void CheckButton(int buttonNumber)
    {
        if (!player) SetSimon();
        if (tmpSimon[0] == buttonNumber)
        {
            Debug.Log(tmpSimon[0]);
            AnimSimon(tmpSimon[0]);
            tmpSimon.Remove(tmpSimon[0]);
        }
        else
        {
            player = false;
            tmpSimon.Clear();
            tmpSimon = simon;
            SetSimon();
            return;
        }
        if (tmpSimon.Count == 0)
        {
            i = 0;
            player = false;
            sequence = false;
            tmpSimon.Clear();
            tmpSimon = simon;
            base.Activated();
            return;
        }
    }

    public void AnimSimon(int buttonclicked)
    {
        meshRenderer[buttonclicked - 1].material = materials[buttonclicked];
    }

    public void SyncSimon(int buttonNumber)
    {
        if (!sequence && !player) SetSimon();
        if (sequence && !player) player = true;
        if (!sequence && player) CheckButton(buttonNumber);
    }
}
