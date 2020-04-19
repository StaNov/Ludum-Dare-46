using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class HealthIndicator : MonoBehaviour
{
    public GuyHealth guyHealth;
    public RectTransform healthBar;

    private float _initHealthBarWidth;

    void Start()
    {
        _initHealthBarWidth = healthBar.rect.width;
    }

    void Update()
    {
        healthBar.sizeDelta = new Vector2(
            guyHealth.currentHealth / 100 * _initHealthBarWidth,
            healthBar.sizeDelta.y
        );
    }
}
