using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticSaw : MonoBehaviour
{
    [SerializeField]
    float RotationSpeed = 20f;

    private SpriteRenderer _sr;

    // Start is called before the first frame update
    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _sr.transform.Rotate(0, 0, -RotationSpeed * Time.deltaTime);
    }
}
