using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreTexts : MonoBehaviour
{
    public Text valueField;
    public Text teamField;
    
    void Start()
    {
        valueField.text = HighScoreManager.Score.ToString();
        teamField.text = HighScoreManager.Team;
    }
}
