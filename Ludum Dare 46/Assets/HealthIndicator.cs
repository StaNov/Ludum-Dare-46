using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class HealthIndicator : MonoBehaviour
{
    public GuyHealth guyHealth;

    private Text _textField;
    void Start()
    {
        _textField = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        _textField.text = Mathf.FloorToInt(guyHealth.currentHealth) + " / 100";
    }
}
