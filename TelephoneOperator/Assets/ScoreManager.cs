using System;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshPro textMesh;

    int score;

    int solveScore = 0;
    int timeBonus = 0;
    int penalty = 0;


    private void Start()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        textMesh.text = score.ToString();
    }

    public void AddScore(int time)
    {
        int amount = (time * timeBonus) + solveScore;
        Debug.Log("Time Left: " + time + "\n Solve Score: " + solveScore);
        score += amount;
        UpdateText();
    }

    public void Penalty()
    {
        score -= penalty;
        UpdateText();
    }

    public int GetScore()
    {
        return score;
    }

    public void SetupLevel(int solve, int time, int pen)
    {
        score = 0;
        solveScore = solve;
        timeBonus = time;
        penalty = pen;
    }
}
