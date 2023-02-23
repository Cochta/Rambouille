using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SawBody : MonoBehaviour
{
    public float Speed = 10;
    public float TimeOffset = 1;
    public Vector2 Direction;

    public float RotationSpeed = 2f;

    private Rigidbody2D _rb;
    private SpriteRenderer _sr;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _sr.transform.Rotate(0, 0, RotationSpeed);
        _rb.velocity = Direction * Speed;
    }
}
