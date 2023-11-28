using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftState : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "JumpableWall")
        {
            _animator.SetBool("TouchWallLeft", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "JumpableWall")
        {
            _animator.SetBool("TouchWallLeft", false);
        }
    }
}
