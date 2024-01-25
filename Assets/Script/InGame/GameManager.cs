using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class GameManager : MonoBehaviour
{
    GameObject _player1;
    GameObject _player2;
    [SerializeField] Text _timeTx;
    [SerializeField] Text _winner;
    GameObject[] _playerArr;
    float _time = 99;
    public GameObject[] PlayerArr { get { return _playerArr; } }
    // Start is called before the first frame update
    void Start()
    {
        _playerArr = GameObject.FindGameObjectsWithTag("Player");
        if (_playerArr[0].transform.position.x < _playerArr[1].transform.position.x)
        {
            _playerArr[0].tag = "Player1";
            _playerArr[1].tag = "Player2";
            _playerArr[0].GetComponent<PlayerData>().Player1 = true;
            _playerArr[1].GetComponent<PlayerData>().Player1 = false;
            _player1 = _playerArr[0];
            _player2 = _playerArr[1];
        }
        else
        {
            _playerArr[1].tag = "Player1";
            _playerArr[0].tag = "Player2";
            _playerArr[1].GetComponent<PlayerData>().Player1 = true;
            _playerArr[0].GetComponent<PlayerData>().Player1 = false;
            _player1 = _playerArr[1];
            _player2 = _playerArr[0];
        }
        _playerArr[0].GetComponent<PlayerData>().Enemy = _playerArr[1];
        _playerArr[1].GetComponent<PlayerData>().Enemy = _playerArr[0];
    }

    // Update is called once per frame
    void Update()
    {
        _time -= Time.deltaTime;
        int intTime = (int)_time;
        _timeTx.text = (intTime.ToString());
    }

    public void lose(string player)
    {
        if (player == "Player1")
            _winner.text = "2P PLAYER WIN";
        else _winner.text = "1P PLAYER WIN";
    }
}
