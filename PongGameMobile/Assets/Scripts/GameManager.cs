using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    public int scorePlayer1, scorePlayer2;
    public ScoreText scoreTextRed,scoreTextBlue;
    public Action onReset;

    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }



    public void OnScoreZoneReached(int id)
    {


            onReset?.Invoke();

        if (id == 1)
            scorePlayer1++;

        if(id == 2)
            scorePlayer2++;

        UpdateScores();
        HighlightScore(id);
    }

    private void UpdateScores()
    {
        scoreTextBlue.SetScore(scorePlayer1);
        scoreTextRed.SetScore(scorePlayer2);
    }

    public void HighlightScore(int id)
    { 
        if(id ==1) 
            scoreTextBlue.Highlight();
        else 
            scoreTextRed.Highlight();

    }
}
