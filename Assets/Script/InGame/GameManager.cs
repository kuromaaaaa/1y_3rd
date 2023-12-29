using System.Collections;
using System.Collections.Generic;
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
    // Start is called before the first frame update
    void Start()
    {
        _p1Tx = _p1HP.GetComponent<Text>();
        _p2Tx = _p2HP.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        _p1Tx.text = ("Player1 HP" + " " + _player1.GetComponent<PlayerData>().NowHp);
        _p2Tx.text = ("Player2 HP" + " " + _player2.GetComponent<PlayerData>().NowHp);
    }
}
