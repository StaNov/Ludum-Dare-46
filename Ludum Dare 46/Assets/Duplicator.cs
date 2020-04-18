using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Duplicator : MonoBehaviour
{
    public int count = 20;
    public Transform numberTextPrefab;
    void Awake()
    {
        for (int i = 0; i < count; i++) {
            Transform duplicate = Instantiate(numberTextPrefab, transform);
            duplicate.GetComponent<Text>().text = (i + 1).ToString().PadLeft(2);
        }
    }
}
