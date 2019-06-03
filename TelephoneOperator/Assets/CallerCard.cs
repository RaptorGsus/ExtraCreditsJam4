using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CallerCard : MonoBehaviour
{
    public GameObject card;
    public bool isHidden = true;

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
                timerRunning = false;
                HideCard();
                
                
            }
        }
        
    }

    public void SetCard(Caller caller)
    {
        timer = 0.0f;
        timerRunning = true;

        nameTextMesh.text = caller.name;
        numberTextMesh.text = caller.goal.ToString();
        infoTextMesh.text = caller.info;
        timeLimit = caller.timeLimit;

        currentCaller = caller;

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
}
