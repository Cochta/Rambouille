using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawChainCollider : MonoBehaviour
{
    private BoxCollider2D _col;
    private SpriteRenderer _sr;

    private void Start()
    {
        _col = GetComponent<BoxCollider2D>();
        _sr = GetComponent<SpriteRenderer>();

        _col.size = new Vector2(_sr.size.x, _sr.size.y);
    }
}
