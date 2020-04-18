using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class FoodSpawner : MonoBehaviour
{
    public GameObject foodPrefab;
    
    void Start()
    {
        Instantiate(foodPrefab, new Vector2(3, 3), Quaternion.identity);
    }
}
