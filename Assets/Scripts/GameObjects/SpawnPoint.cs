using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private Animator _animator;

    [NonSerialized]
    public PlayerSpawner _playerSpawner;

    //[SerializeField]
    //private bool _isStart = false;
    //[SerializeField]
    //private bool _isEnd = false;
    [SerializeField]
    private bool _isCheckPoint = false;

    void Start()
    {
        _playerSpawner = GetComponentInParent<PlayerSpawner>();

        if (_isCheckPoint)
        {
            _animator = GetComponentInParent<Animator>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && _isCheckPoint)
        {
            _animator.SetBool("Reached", true);
        }
        if (collision.tag == "Player")
        {
            _playerSpawner._lastCheckPoint = gameObject.transform;
        }
    }
}
