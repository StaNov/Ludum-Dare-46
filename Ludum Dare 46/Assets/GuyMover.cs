using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuyMover : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        _rigidbody2D.AddForce(new Vector2(1, 1) * 1.00001f, ForceMode2D.Impulse);
    }
}
