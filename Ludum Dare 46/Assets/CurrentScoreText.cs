using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentScoreText : MonoBehaviour
{
    public CurrentScoreHolder currentScoreHolder;

    private Text _text;
    
    void Awake()
    {
        _text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        string currentScore = currentScoreHolder.CurrentScore.ToString();
        if (currentScore != _text.text)
        {
            _text.text = currentScore;
        }
    }
}
