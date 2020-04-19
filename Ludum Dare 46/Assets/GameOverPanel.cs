using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{
    public Text pointMessage;
    public Text restartMessage;
    public Text highScoreText;
    public CurrentScoreHolder currentScoreHolder;
    public CurrentPlayersHolder currentPlayersHolder;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void Activate()
    {
        gameObject.SetActive(true);
        
        if (currentScoreHolder.CurrentScore > HighScoreManager.Score)
        {
            HighScoreManager.Score = currentScoreHolder.CurrentScore;
            HighScoreManager.Team = string.Join("\n", currentPlayersHolder.currentPlayers);
        }
        else
        {
            highScoreText.gameObject.SetActive(false);        
        }
        
        pointMessage.text = pointMessage.text.Replace("XXX", currentScoreHolder.CurrentScore.ToString());
        StartCoroutine(CountDownAndRestart());
    }

    private IEnumerator CountDownAndRestart()
    {
        float restartTime = Time.time + 5;
        string template = restartMessage.text;

        while (Time.time < restartTime)
        {
            string secondsToRestart = Mathf.CeilToInt(restartTime - Time.time).ToString();
            restartMessage.text = template.Replace("XXX", secondsToRestart);
            yield return null;
        }

        restartMessage.text = "Restarting...";
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
