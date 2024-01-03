using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject _player1;
    [SerializeField] GameObject _player2;
    [SerializeField] GameObject _p1HP;
    [SerializeField] GameObject _p2HP;
    Text _p1Tx;
    Text _p2Tx;
    [SerializeField] TagUnitType _p1tag;
    [SerializeField] TagUnitType _p2tag;
    GameObject[] _playerArr;

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
        }
        else
        {
            _playerArr[1].tag = "Player1";
            _playerArr[0].tag = "Player2";
            _playerArr[1].GetComponent<PlayerData>().Player1 = true;
            _playerArr[0].GetComponent<PlayerData>().Player1 = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        _p1Tx.text = ("Player1 HP" + " " + _player1.GetComponent<PlayerData>().NowHp);
        _p2Tx.text = ("Player2 HP" + " " + _player2.GetComponent<PlayerData>().NowHp);
    }
}
