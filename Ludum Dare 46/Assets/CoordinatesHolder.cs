using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinatesHolder : MonoBehaviour
{
    private float[] xs;
    private float[] ys;

    public Transform xsHolder;
    public Transform ysHolder;

    private bool filled = false;
    void Update()
    {
        if (filled) return;
        
        xs = new float[xsHolder.childCount];
        for (int i = 0; i < xsHolder.childCount; i++)
        {
            Transform child = xsHolder.GetChild(i);
            xs[i] = child.position.x;
        }
        
        ys = new float[ysHolder.childCount];
        for (int i = 0; i < ysHolder.childCount; i++)
        {
            Transform child = ysHolder.GetChild(i);
            ys[i] = child.position.y;
        }

        if (Math.Abs(Math.Abs(xs[0]) - Math.Abs(xs[1])) > 0.001)
            filled = true;
    }
}
