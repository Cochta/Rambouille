using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotState : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private Rigidbody2D _playerRB;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground" || collision.tag == "JumpableWall")
        {
            _animator.SetBool("IsGrounded", true);
            _playerRB.velocity = new Vector2(_playerRB.velocity.x, 0);
        }
        if (collision.tag == "Head")
        {
            StartCoroutine(collision.GetComponentInParent<CollisionHandeler>().Death());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground" || collision.tag == "JumpableWall")
        {
            _animator.SetBool("IsGrounded", false);
        }
    }
}
