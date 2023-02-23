using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoJumpOut : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _tuto;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            foreach (var item in _tuto)
            {
                item.SetActive(false);
            }
        }
    }
}
