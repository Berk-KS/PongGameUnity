using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUi : MonoBehaviour
{
    public ScoreText scoreTextRed, scoreTextBlue;
    public GameObject menuObject;

    public void UpdateScores(int scorePlayer1,int scorePlayer2)
    {
        scoreTextBlue.SetScore(scorePlayer1);
        scoreTextRed.SetScore(scorePlayer2);
    }

    public void HighlightScore(int id)
    {
        if (id == 1)
            scoreTextBlue.Highlight();
        else
            scoreTextRed.Highlight();

    }
    public void OnPlayGameButtonClicked()
    {
        Debug.Log("bas");
        menuObject.SetActive(true);

    }


}
