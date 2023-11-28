using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class PlayerStates : MonoBehaviour
{
    private Rigidbody2D _playerRigidbody;
    private Animator _animator;

    private void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerRigidbody.velocity.x > 0.1 || _playerRigidbody.velocity.x < -0.1)
        {
            _animator.SetBool("IsMoving", true);

        }
        else
        {
            _animator.SetBool("IsMoving", false);
        }

        if (_animator.GetBool("TouchWallRight") || _animator.GetBool("TouchWallLeft"))
        {
            _animator.SetBool("TouchWall", true);
        }
        else
        {
            _animator.SetBool("TouchWall", false);
        }

        if (_playerRigidbody.velocity.y > math.EPSILON)
        {
            _animator.SetBool("IsJumping", true);
        }
        else if (_playerRigidbody.velocity.y < math.EPSILON)
        {
            _animator.SetBool("IsJumping", false);
            _animator.SetBool("IsFalling", true);
        }

        if (_animator.GetBool("IsGrounded"))
        {
            _animator.SetBool("IsJumping", false);
            _animator.SetBool("IsFalling", false);
        }
        if (_animator.GetBool("IsJumping"))
        {
            _animator.SetBool("IsFalling", false);
        }
        if (_animator.GetBool("IsFalling"))
        {
            _animator.SetBool("IsJumping", false);
        }
    }
}
