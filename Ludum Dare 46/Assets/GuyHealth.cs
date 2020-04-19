using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GuyHealth : MonoBehaviour
{
    public float currentHealth = 100;
    public GuyMover guyMover;
    public GameOverPanel gameOverPanel;

    public int healthPerSecondDecrement = 2;

    void Update()
    {
        currentHealth -= healthPerSecondDecrement * Time.deltaTime;

        if (currentHealth < 0)
        {
            guyMover.Stop();
            gameOverPanel.Activate();
            gameObject.SetActive(false);
        }
    }

    public void AddHealth(int healthValue)
    {
        currentHealth = Math.Min(currentHealth + healthValue, 100);
    }
}
