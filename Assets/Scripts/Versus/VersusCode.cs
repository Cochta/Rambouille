using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VersusCode : MonoBehaviour
{
    [NonSerialized] public int Player1HP = 5;
    [NonSerialized] public int Player2HP = 5;
    [SerializeField] private TextMeshProUGUI P1Text;
    [SerializeField] private TextMeshProUGUI P2Text;
    [SerializeField] private Image _p1Rock;
    [SerializeField] private Image _p2Rock;

    [SerializeField] private Transform _spawner1;
    [SerializeField] private Transform _spawner2;
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private GameObject[] _worlds;

    private System.Random rng = new System.Random();

    private GameObject _player1, _player2;
    private PlayerController _contr1, _contr2;

    [SerializeField]
    private GameObject _endMenu;
    [SerializeField]
    private TextMeshProUGUI _winText;

    [SerializeField] private EventSystem _sys;

    private bool IsGameEnd = false;
    private void Start()
    {
        SetUpWorld();
        SpawnPlayers(1);
        SpawnPlayers(2);
    }
    // Update is called once per frame
    void Update()
    {
        if (!IsGameEnd)
        {
            if (Player1HP <= 0 || Player2HP <= 0)
            {
                _sys.enabled = true;
                IsGameEnd = true;
                Time.timeScale = 0;
                _endMenu.SetActive(true);
                if (Player1HP <= 0 && Player2HP <= 0)
                {
                    _winText.text = "Draw";
                    _winText.color = Color.black;
                }
                else if (Player1HP <= 0)
                {
                    _winText.text = "Red Wins";
                    _winText.color = Color.red;
                }
                else if (Player2HP <= 0)
                {
                    _winText.text = "Green Wins";
                    _winText.color = Color.green;
                }
            }
        }
        if (_player1 == null)
        {
            SpawnPlayers(1);
            _player2.transform.position = _spawner2.transform.position;
            Player1HP -= 1;
            P1Text.text = Player1HP.ToString();
            StartCoroutine(ScoreFeedback(P1Text));
            if (!IsGameEnd)
                SetUpWorld();
        }
        else if (_player2 == null)
        {
            SpawnPlayers(2);
            _player1.transform.position = _spawner1.transform.position;
            Player2HP -= 1;
            P2Text.text = Player2HP.ToString();
            StartCoroutine(ScoreFeedback(P2Text));
            if (!IsGameEnd)
                SetUpWorld();
        }
        if (_contr1.CanRockSolid)
            _p1Rock.color = Color.white;
        else if (!_contr1.CanRockSolid)
            _p1Rock.color = Color.grey;
        if (_contr2.CanRockSolid)
            _p2Rock.color = Color.white;
        else if (!_contr2.CanRockSolid)
            _p2Rock.color = Color.grey;

    }
    public void SetUpWorld()
    {
        foreach (var world in _worlds)
        {
            world.SetActive(false);
        }
        _worlds[rng.Next(0, _worlds.Length)].SetActive(true);
    }
    public void PlayAgain()
    {
        Time.timeScale = 1.0f;
        SetUpWorld();
        Player1HP = 5;
        Player2HP = 5;
        _endMenu.SetActive(false);
        IsGameEnd = false;
        P1Text.text = Player1HP.ToString();
        P2Text.text = Player2HP.ToString();
        _sys.enabled = false;
    }
    public void SpawnPlayers(int player)
    {
        if (player == 1)
        {
            _player1 = Instantiate(_playerPrefab, _spawner1);
            _player1.GetComponent<SpriteRenderer>().color = Color.green;
            _contr1 = _player1.GetComponent<PlayerController>();
        }
        if (player == 2)
        {
            _player2 = Instantiate(_playerPrefab, _spawner2);
            _player2.GetComponent<SpriteRenderer>().color = Color.red;
            _contr2 = _player2.GetComponent<PlayerController>();
        }
    }

    IEnumerator ScoreFeedback(TextMeshProUGUI text)
    {
        text.fontSize = 150;
        text.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        text.fontSize = 100;
        text.color = Color.black;
    }
}
