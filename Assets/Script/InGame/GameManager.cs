using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    GameObject _player1;
    GameObject _player2;
    [SerializeField] GameObject _p1HP;
    [SerializeField] GameObject _p2HP;
    Text _p1Tx;
    Text _p2Tx;
    GameObject[] _playerArr;
    public GameObject[] PlayerArr { get { return _playerArr; } }
    // Start is called before the first frame update
    void Start()
    {
        _p1Tx = _p1HP.GetComponent<Text>();
        _p2Tx = _p2HP.GetComponent<Text>();
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
        _p1Tx.text = ("Player1 HP" + " " + _player1.GetComponent<PlayerData>().NowHp);
        _p2Tx.text = ("Player2 HP" + " " + _player2.GetComponent<PlayerData>().NowHp);
    }
}
