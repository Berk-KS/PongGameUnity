using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public int scorePlayer1, scorePlayer2;
    public ScoreText scoreTextRed,scoreTextBlue;
    //public Action onReset;
    public void OnScoreZoneReached(int id)
    {
       // onReset?.Invoke();



        if (id == 1)
            scorePlayer1++;

        if(id==2)
            scorePlayer2++;

        UpdatesScores();
    }

    public void UpdatesScores()
    {
        scoreTextBlue.SetScore(scorePlayer1);
        scoreTextRed.SetScore(scorePlayer2);
    }

}
