using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentScoreHolder : MonoBehaviour
{
    private int _currentScore = 0;

    public int CurrentScore
    {
        get { return _currentScore; }
        set { _currentScore = Math.Max(0, value); }
    }
}
