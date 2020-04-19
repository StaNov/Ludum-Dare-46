using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public int healthValue = 30;
    public CurrentScoreHolder currentScoreHolder;

    private float _timeToLive = 15;
    void Update()
    {
        _timeToLive -= Time.deltaTime;

        if (_timeToLive < 0)
        {
            Destroy(gameObject);
            currentScoreHolder.CurrentScore--;
        }
    }
}
