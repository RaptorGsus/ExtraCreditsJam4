using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public CallerCard card;
    public List<Caller> callers;
    private bool levelRunning = false;

    public bool startLevelOnAwake = false;

    private void Awake()
    {
        if (startLevelOnAwake) {
            StartLevel();
        }
    }

    public List<Caller> GetCallers()
    {
        return callers;
    }

    public void ResetLevel()
    {
        foreach(Caller c in callers) {
            c.completed = false;
        }
    }

    public Caller GetNextCaller()
    {
        foreach(Caller c in callers) {
            if (!c.completed) {
                c.completed = true;
                return c;
            }
        }
        return null;
    }

    private void Update()
    {
        if (levelRunning) {
            if (card.IsEmpty()) {

                Caller caller = GetNextCaller();
                if (caller != null) {
                    card.SetCard(GetNextCaller());
                } else {
                    EndLevel();
                }
            }
        }
       
    }

    public void StartLevel()
    {
        levelRunning = true;
        card.Unpause();
    }

    public void PauseLevel()
    {
        levelRunning = false;
        card.Pause();
    }

    private void EndLevel()
    {
        Debug.Log("Level Ended!");
        levelRunning = true;
    }
}

[System.Serializable]
public class Caller
{
    public string name;
    public bool completed;
    [TextArea(1, 5)]
    public string info;
    public int goal;
    public float timeLimit;
    public string[] emotes;
}
