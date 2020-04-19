using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    public static int Score
    {
        get
        {
            return PlayerPrefs.GetInt("highScore", 0);
        }
        set
        {
            PlayerPrefs.SetInt("highScore", value);
            PlayerPrefs.Save();
        }
    }

    public static string Team
    {
        get
        {
            return PlayerPrefs.GetString("highScoreTeam", "");
        }
        set
        {
            PlayerPrefs.SetString("highScoreTeam", value);
            PlayerPrefs.Save();
        }
    }
}
