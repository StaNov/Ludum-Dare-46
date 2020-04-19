using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuyEater : MonoBehaviour
{
    public GuyHealth guyHealth;
    public CurrentScoreHolder currentScoreHolder;

    private void OnTriggerEnter2D(Collider2D other)
    {
        guyHealth.AddHealth(other.GetComponent<Food>().healthValue);
        Destroy(other.gameObject);
        currentScoreHolder.CurrentScore += 5;
    }
}
