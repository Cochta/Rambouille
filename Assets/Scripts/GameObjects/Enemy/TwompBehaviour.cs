using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TwompBehaviour : MonoBehaviour
{
    public float Speed = 10;
    public float TimeOffset = 1;

    private float _direction = -1;
    private Vector3 _position;

    private Rigidbody2D _RB;
    [SerializeField]
    private BoxCollider2D _botCol;

    private Animator _animator;
    private AudioSource _audio;

    // Start is called before the first frame update
    void Start()
    {
        _RB = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (_direction > 0)
        {
            _RB.velocity = new Vector2(0, _direction * Speed / 2);
        }
        else if (_direction < 0)
        {
            _RB.velocity = new Vector2(0, _direction * Speed);
        }
        else if (_direction == 0)
        {
            _RB.velocity = Vector2.zero;
        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            StartCoroutine("TouchGround");
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "UpTwomp")
        {
            StartCoroutine("TouchUp");
        }
    }
    IEnumerator TouchGround()
    {
        _botCol.enabled = false;
        _animator.SetBool("IsFalling", false);
        _animator.SetBool("IsPrepUp", true);
        _direction = 0;
        yield return new WaitForSeconds(TimeOffset / 2);
        _animator.SetBool("IsUp", true);
        _animator.SetBool("IsPrepUp", false);
        _direction = 1;

    }
    IEnumerator TouchUp()
    {
        _animator.SetBool("IsUp", false);
        _animator.SetBool("IsPrepFalling", true);
        _direction = 0;
        yield return new WaitForSeconds(TimeOffset);
        _animator.SetBool("IsFalling", true);
        _animator.SetBool("IsPrepFalling", false);
        _botCol.enabled = true;
        _direction = -1;
        _audio.Play();

    }
}
