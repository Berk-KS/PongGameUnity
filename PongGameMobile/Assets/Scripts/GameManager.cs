using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameUi gameUi;
    public int scorePlayer1, scorePlayer2;
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

        gameUi.UpdateScores(scorePlayer1,scorePlayer2);
        gameUi.HighlightScore(id);
    }

}
