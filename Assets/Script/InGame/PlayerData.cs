using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    [SerializeField] int _maxPlayerHP;
    Image _hpImage;
    GameObject _gm;
    int _nowHp;
    public int NowHp {  get { return _nowHp; } }
    bool _player1;
    bool _playerDirecRight;
    public bool PlayerDirecRight { get { return _playerDirecRight; } }
    GameObject _enemy;
    public GameObject Enemy { set { _enemy = value; } get { return _enemy; } }
    public bool Player1 { set { _player1 = value; } }
    bool _damaging = false;
    public bool Damaging 
    {
        set { _damaging = value; }
        get { return _damaging; }
    }
    bool _isGround = false;
    public bool IsGround { get { return _isGround; } }
    // Start is called before the first frame update
    void Start()
    {
        _nowHp = _maxPlayerHP;
        if (this.gameObject.tag == "Player1")
        {
            _hpImage = GameObject.Find("HPbar1P_blue").GetComponent<Image>();
        }
        else 
        { 
            _hpImage = GameObject.Find("HPbar2P_blue").GetComponent<Image>();
        }
        _gm = GameObject.Find("GameManager");
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
        if(_nowHp <= 0)
        {
            _gm.GetComponent<GameManager>().lose(gameObject.tag);
        }
        _hpImage.fillAmount = 1f * _nowHp / _maxPlayerHP;
    }

    public void MinusHP(int minus)
    {
        _nowHp -= minus;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            _isGround = true;
            _damaging = false;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            _isGround = false;
        }
    }
}
