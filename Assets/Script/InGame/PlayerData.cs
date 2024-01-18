using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] int _maxPlayerHP;
    int _nowHp;
    public int NowHp {  get { return _nowHp; } }
    bool _player1;
    bool _playerDirecRight;
    public bool PlayerDirecRight { get { return _playerDirecRight; } }
    GameObject _enemy;
    public GameObject Enemy { set { _enemy = value; } get { return _enemy; } }
    public bool Player1 { set { _player1 = value; } }
    bool damaging = false;
    public bool Damaging 
    {
        set { damaging = value; }
        get { return damaging; }
    }

    // Start is called before the first frame update
    void Start()
    {
        _nowHp = _maxPlayerHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x < _enemy.transform.position.x)
        { 
            _playerDirecRight = true;
        }
        else
        {
            _playerDirecRight = false;
        }
    }

    public void MinusHP(int minus)
    {
        _nowHp -= minus;
    }
}
