using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class CallerCard : MonoBehaviour
{
    public GameObject card;
    public bool isHidden = true;

    [Header("Plug")]
    public SocketFemale startSocket;
    public WireTray wires;

    [Header("TextContent")]
    public TextMeshProUGUI nameTextMesh;
    public TextMeshProUGUI numberTextMesh;
    public TextMeshProUGUI infoTextMesh;

    [Header("Timer")]
    public float timeLimit;
    private float timer = 0f;
    bool timerRunning =  false;
    public Image countdownBar;
    public Gradient countdownBarGradient;
    public ScoreManager scoreManager;

    [Header("Audio")]
    public AudioClip ringAudio;

    private Caller currentCaller;

    private void Update()
    {
        if (!isHidden && timerRunning) {
            timer += Time.deltaTime;
            countdownBar.fillAmount = 1 - timer / timeLimit;
            countdownBar.color = countdownBarGradient.Evaluate(1 - timer / timeLimit);

            if (timer >= timeLimit) {
                Expire();
                
            }
        }
        
    }

    private void Expire()
    {
        //Stop timer and remove card
        timerRunning = false;
        HideCard();
        //Apply Pentalty
        scoreManager.Penalty();
    }

    internal void Solve()
    {
        //Stop Timer and hide card.
        timerRunning = false;
        HideCard();
        //Award Score
        int timebonus = Mathf.RoundToInt(currentCaller.timeLimit - timer);
        scoreManager.AddScore(timebonus);
        wires.ResetWires();

    }

    public void SetCard(Caller caller)
    {
        timer = 0.0f;
        timerRunning = true;
        nameTextMesh.text = caller.name;
        numberTextMesh.text = caller.goal.ToString();
        infoTextMesh.text = caller.info;
        timeLimit = caller.timeLimit;
        ShowCard();
        currentCaller = caller;
    }

    public string GetExpression()
    {
        string result = "b";
        startSocket.GetSwitch().Visit(ref result);
        Debug.Log(result);
        return result;
    }

    public void Pause()
    {
        timerRunning = false;
    }

    public void Unpause()
    {
        timerRunning = true;
    }

    private void HideCard()
    {
        card.SetActive(false);
        isHidden = true;
    }

    public void ShowCard()
    {
        GetComponent<AudioSource>().PlayOneShot(ringAudio);
        isHidden = false;
        card.SetActive(true);
    }

    public bool IsEmpty()
    {
        return isHidden;
    }

    public int GetGoal()
    {
        return currentCaller.goal;
    }


}
