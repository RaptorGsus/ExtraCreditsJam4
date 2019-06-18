using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public CallerCard card;
    public int solvescore;
    public int timeBonus;
    public int pentalty;
    public List<Caller> callers;
    private bool levelRunning = false;

    public bool startLevelOnAwake = false;

    public GameObject levelComplete;
    public ScoreManager scoreManager;

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
                    card.SetCard(caller);
                } else {
                    EndLevel();
                }
            }
        }
       
    }

    public void StartLevel()
    {
        card.SetCard(callers[0]);
        levelRunning = true;
        card.Unpause(); 
        scoreManager.SetupLevel(solvescore, timeBonus, pentalty);
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
        levelComplete.SetActive(true);
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
