using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFoodManager : MonoBehaviour
{
    public Sprite[] foodSprites;
    
    public Sprite GetFoodForPlayer(string playerName)
    {
        if (!PlayerPrefs.HasKey("Food_" + playerName))
        {
            PlayerPrefs.SetInt("Food_" + playerName, Random.Range(0, foodSprites.Length - 1));
        }
        
        int i = PlayerPrefs.GetInt("Food_" + playerName, Random.Range(0, foodSprites.Length - 1));

        return foodSprites[i];
    }
}
