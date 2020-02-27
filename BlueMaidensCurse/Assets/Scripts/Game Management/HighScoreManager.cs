using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour
{
    [SerializeField] uint currentScore = 0;
    uint gainedScore = 0;
    [SerializeField] Text highScoreText;

    public void Awake()
    {
        highScoreText.text = 0 + "";
    }
    public void Update()
    {
        if(currentScore != gainedScore)
        {
            currentScore = gainedScore;
            highScoreText.text = currentScore + "";
        }
    }

    public void AddScore(uint score)
    {
        gainedScore += score;
    }
}
