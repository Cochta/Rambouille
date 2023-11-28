using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer[] _srs;

    private float _speed = 0.05f;

    // Update is called once per frame
    void Update()
    {
        foreach (var sr in _srs)
        {
            sr.material.mainTextureOffset += new Vector2(_speed * Time.deltaTime, 0);
        }
    }
}
