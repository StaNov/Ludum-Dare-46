using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject _foodPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(_foodPrefab, new Vector2(3, 3), Quaternion.identity);
    }
}
