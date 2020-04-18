using System;
using UnityEngine;

public class CoordinatesHolder : MonoBehaviour
{
    private float[] _xs;
    private float[] _ys;

    public Transform xsHolder;
    public Transform ysHolder;
    public bool IsReady { get; private set; }

    void Update()
    {
        if (IsReady) return;
        
        _xs = new float[xsHolder.childCount];
        for (int i = 0; i < xsHolder.childCount; i++)
        {
            Transform child = xsHolder.GetChild(i);
            _xs[i] = child.position.x + 0.9f; // hack
        }
        
        _ys = new float[ysHolder.childCount];
        for (int i = 0; i < ysHolder.childCount; i++)
        {
            Transform child = ysHolder.GetChild(i);
            _ys[i] = child.position.y + 0.7f; // hack
        }

        if (Math.Abs(Math.Abs(_xs[0]) - Math.Abs(_xs[1])) > 0.001)
            IsReady = true;
    }

    public Vector2 getPositionOfCoordinates(int x, int y)
    {
        return new Vector2(_xs[x - 1], _ys[y - 1]);
    }
}
