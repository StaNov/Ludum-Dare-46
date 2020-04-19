using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GuyHealth : MonoBehaviour
{
    public float currentHealth = 100;
    public CurrentScoreHolder currentScoreHolder;
    public CurrentPlayersHolder currentPlayersHolder;
    public GuyMover guyMover;
    public GameOverPanel gameOverPanel;

    public int healthPerSecondDecrement = 2;

    void Update()
    {
        currentHealth -= healthPerSecondDecrement * Time.deltaTime;

        if (currentHealth < 0)
        {
            if (currentScoreHolder.CurrentScore > HighScoreManager.Score)
            {
                HighScoreManager.Score = currentScoreHolder.CurrentScore;
                HighScoreManager.Team = string.Join("\n", currentPlayersHolder.currentPlayers);
            }
            
            guyMover.Stop();
            gameOverPanel.Activate();
        }
    }

    public void AddHealth(int healthValue)
    {
        currentHealth = Math.Min(currentHealth + healthValue, 100);
    }
}
