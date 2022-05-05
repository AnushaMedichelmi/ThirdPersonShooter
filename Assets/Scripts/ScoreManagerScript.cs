using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManagerScript : MonoBehaviour
{
    int score;
    public Text scoreText;

    public void Score(int scoreValue)
    {
        score = score + scoreValue;
        Debug.Log("SCORE:"+ score);
        scoreText.text = score.ToString();
        if(score > 30)
        {
            Debug.Log("Your are the Winner");
        }
    }
}
