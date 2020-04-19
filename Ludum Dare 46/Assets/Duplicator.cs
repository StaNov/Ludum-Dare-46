using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Duplicator : MonoBehaviour
{
    public int count = 20;
    public Transform numberTextPrefab;
    public bool letters;
    void Awake()
    {
        for (int i = 0; i < count; i++) {
            Transform duplicate = Instantiate(numberTextPrefab, transform);
            duplicate.GetComponent<Text>().text = GetText(i).PadLeft(2);
        }
    }

    private string GetText(int i)
    {
        if (!letters)
        {
            return (count - i).ToString();
        }

        return ((char) ('A' + i)).ToString();
    }
}
