using Microsoft.Cci;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float _speed = 7f;
    private float _jumpSpeed = 19;

    private float _coyoteTime;

    private bool _isWallJumping = false;

    private float value;

    private bool _paused = false;

    [NonSerialized]
    public bool CanDoubleJump = false;

    [SerializeField]
    private AudioClip _jump;
    [SerializeField]
    private AudioClip _spawn;

    private Rigidbody2D _playerRigidbody;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private PlayerInput _input;
    private AudioSource _audio;

    public bool CanRockSolid = true;
    private float _rocksolidCooldown = 10;
    private void Start()
    {
        _input = GetComponent<PlayerInput>();
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _audio = GetComponent<AudioSource>();
        _audio.volume = PlayerPrefs.GetFloat("Volume");
        _audio.clip = _spawn;
        _audio.Play();
        StartCoroutine("Spawn");
    }

    void FixedUpdate()
    {
        if (!_animator.GetBool("TouchWall"))
        {
            if (_playerRigidbody.velocity.x < -0.1)
                _spriteRenderer.flipX = true;
            if (_playerRigidbody.velocity.x > 0.1)
                _spriteRenderer.flipX = false;
        }

        if (!_isWallJumping)
        {
            _playerRigidbody.velocity = new Vector2(value * _speed, _playerRigidbody.velocity.y);
        }

        if (_playerRigidbody.velocity.y > math.EPSILON)
        {
            _playerRigidbody.velocity = new Vector2(_playerRigidbody.velocity.x, _playerRigidbody.velocity.y - 0.1f);
        }
        else
        {
            _isWallJumping = false;
        }

    }
    private void Update()
    {
        if (_animator.GetBool("IsGrounded") || CanDoubleJump)
        {
            _coyoteTime = 0;
        }
        else
        {
            _coyoteTime += Time.deltaTime;
        }
        if (Time.timeScale != 0)
        {
            _paused = false;
        }
        _rocksolidCooldown += Time.deltaTime;
        if (_rocksolidCooldown >= 5)
            CanRockSolid = true;
        else
            CanRockSolid = false;
    }
    public void HandlePause(InputAction.CallbackContext ctx)
    {
        if (ctx.started && !_paused)
        {
            Time.timeScale = 0;
            SceneManager.LoadScene("Pause", LoadSceneMode.Additive);
            _paused = true;
        }
    }
    public void HandleMove(InputAction.CallbackContext ctx)
    {
        value = ctx.ReadValue<float>();
    }
    public void HandleRockSolid(InputAction.CallbackContext ctx)
    {
        if (ctx.started && CanRockSolid)
        {
            StartCoroutine(RockSolid());
        }
    }
    public void HandleJump(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            if (_animator.GetBool("IsGrounded") || _coyoteTime <= 0.05 || CanDoubleJump)
            {
                _audio.clip = _jump;
                _audio.Play();
                _playerRigidbody.velocity = new Vector2(_playerRigidbody.velocity.x, 0);
                _playerRigidbody.AddForce(new Vector2(0, _jumpSpeed), ForceMode2D.Impulse);
                CanDoubleJump = false;
                _isWallJumping = false;
            }
            else if (_animator.GetBool("TouchWallLeft"))
            {
                _audio.clip = _jump;
                _audio.Play();
                _isWallJumping = true;
                _playerRigidbody.velocity = new Vector2(0, 0);
                _playerRigidbody.AddForce(new Vector2(-_jumpSpeed / 2, _jumpSpeed), ForceMode2D.Impulse);
            }
            else if (_animator.GetBool("TouchWallRight"))
            {
                _audio.clip = _jump;
                _audio.Play();
                _isWallJumping = true;
                _playerRigidbody.velocity = new Vector2(0, 0);
                _playerRigidbody.AddForce(new Vector2(_jumpSpeed / 2, _jumpSpeed), ForceMode2D.Impulse);
            }

        }
    }
    IEnumerator Spawn()
    {
        _animator.SetBool("IsSpawning", true);

        yield return new WaitForSeconds(0.5f);
        _input.enabled = true;
        _animator.SetBool("IsSpawning", false);

    }
    IEnumerator RockSolid()
    {
        _rocksolidCooldown = 0;
        Color oldColor = _spriteRenderer.color;
        _spriteRenderer.color = Color.grey;
        GetComponent<BoxCollider2D>().enabled = false;
        foreach (var col in GetComponentsInChildren<BoxCollider2D>())
        {
            col.enabled = false;
        }
        _playerRigidbody.simulated = false;
        yield return new WaitForSeconds(1f);
        _spriteRenderer.color = oldColor;
        GetComponent<BoxCollider2D>().enabled = true;
        foreach (var col in GetComponentsInChildren<BoxCollider2D>())
        {
            col.enabled = true;
        }
        _playerRigidbody.simulated = true;
    }
}