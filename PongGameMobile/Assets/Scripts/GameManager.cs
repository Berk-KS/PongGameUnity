using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameUI gameUI;
    public int scorePlayer1, scorePlayer2;
    public Action onReset;
    public int maxScore = 4;

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

        gameUI.UpdateScores(scorePlayer1,scorePlayer2);
        gameUI.HighlightScore(id);
        CheckWin();
    }

    private void CheckWin()
    {
        int winnerId = scorePlayer1 == maxScore? 1 : scorePlayer2 == maxScore? 2 : 0;

        if (winnerId != 0)
        {
            //kazanan
            gameUI.OnGameEnds(winnerId);
        }


    }

}
