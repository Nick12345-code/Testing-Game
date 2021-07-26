using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private Text scoreText;

    public void UpdateScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }
}
