using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuyHealth : MonoBehaviour
{
    private float _currentHealth = 100;

    public int healthPerSecondDecrement = 2;

    void Update()
    {
        _currentHealth -= healthPerSecondDecrement * Time.deltaTime;

        if (_currentHealth < 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
