using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [NonSerialized] public Transform _lastCheckPoint;

    [SerializeField] private Transform _startCheckPoint;
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private CinemachineVirtualCamera _cam;

    private GameObject _player;

    void Start()
    {
        _lastCheckPoint = _startCheckPoint;
    }
    private void Update()
    {
        if (_player == null)
        {
            SpawnPlayer(_lastCheckPoint);
        }
    }

    // Update is called once per frame
    public void SpawnPlayer(Transform transform)
    {
        _player = Instantiate(_playerPrefab, transform);
        _cam.Follow = _player.transform;
    }
}
