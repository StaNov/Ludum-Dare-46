using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GuyHealth : MonoBehaviour
{
    public float currentHealth = 100;

    public int healthPerSecondDecrement = 2;

    void Update()
    {
        currentHealth -= healthPerSecondDecrement * Time.deltaTime;

        if (currentHealth < 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
