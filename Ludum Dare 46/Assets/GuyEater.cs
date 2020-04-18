using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuyEater : MonoBehaviour
{
    public GuyHealth guyHealth;

    private void OnTriggerEnter2D(Collider2D other)
    {
        guyHealth.AddHealth(other.GetComponent<Food>().healthValue);
        Destroy(other.gameObject);
    }
}
