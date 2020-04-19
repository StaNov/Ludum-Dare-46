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

    public void SetFoodForPlayer(string playerName, string foodName)
    {
        int i = 3;

        if (foodName.Equals("candy"))
        {
            i = 0;
        }
        else if (foodName.Equals("cupcake"))
        {
            i = 1;
        }
        else if (foodName.Equals("heart"))
        {
            i = 2;
        }
        else if (foodName.Equals("icecream"))
        {
            i = 3;
        }
        
        PlayerPrefs.SetInt("Food_" + playerName, i);
    }
}
