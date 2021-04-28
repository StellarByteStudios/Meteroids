using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreInGame : MonoBehaviour
{
    private Text scoreText;
    private int scoreValue;

    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreValue = 0;
    }

    void Update()
    {
        scoreText.text = "Score: " + scoreValue;
        ScoreData.setScore(scoreValue);
    }

    public void addScore(int value)
    {
        scoreValue += value; 
    }
    
    public int getScore()
    {
        return scoreValue;
    }
}
