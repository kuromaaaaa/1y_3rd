using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    //HPとHPバー
    [SerializeField] int _maxPlayerHP;
    int _nowHp;
    public int NowHp { get { return _nowHp; } }
    int _comboHp;
    float _hpImageMaxSize;
    RectTransform _hpBarRedRtf;
    RectTransform _hpBarBlueRtf;

    GameObject _gm;
    bool _player1;
    public bool Player1 { set { _player1 = value; } }
    GameObject _enemy;
    public GameObject Enemy { set { _enemy = value; } get { return _enemy; } }
    //プレイヤーの位置と向き
    bool _playerDirecRight;
    public bool PlayerDirecRight { get { return _playerDirecRight; } }
    [SerializeField] bool _flip = false;
    public bool Flip { set { _flip = value; } get { return _flip; } }
    //ダメージとコンボカウント
    bool _damaging = false;
    public bool Damaging
    {
        set { _damaging = value; }
        get { return _damaging; }
    }
    int _isComboedCount = 0;
    public int IsComboCount { set { _isComboedCount = value; } get { return _isComboedCount; } }
    bool _isGround = false;
    public bool IsGround { get { return _isGround; } }
    // Start is called before the first frame update
    void Start()
    {
        _nowHp = _maxPlayerHP;
        if (this.gameObject.tag == "Player1")
        {
            _hpBarBlueRtf = GameObject.Find("HPbar1P_blue").GetComponent<RectTransform>();
            _hpBarRedRtf = GameObject.Find("HPbar1P_red").GetComponent<RectTransform>();
            _hpImageMaxSize = _hpBarBlueRtf.sizeDelta.x;
        }
        else 
        { 
            _hpBarBlueRtf = GameObject.Find("HPbar2P_blue").GetComponent<RectTransform>();
            _hpBarRedRtf = GameObject.Find("HPbar2P_red").GetComponent<RectTransform>();
            _hpImageMaxSize = _hpBarBlueRtf.sizeDelta.x;
        }
        _gm = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x < _enemy.transform.position.x)
        { 
            _playerDirecRight = _flip ? false : true;
        }
        else
        {
            _playerDirecRight = _flip ? true : false;
        }
        if(_nowHp <= 0)
        {
            _gm.GetComponent<GameManager>().lose(gameObject.tag);
        }
        _hpBarBlueRtf.sizeDelta = new Vector2(_hpImageMaxSize * (1.0f * _nowHp / _maxPlayerHP),_hpBarBlueRtf.sizeDelta.y);
        if(!_damaging || _nowHp <= 0)
        _hpBarRedRtf.sizeDelta = new Vector2(_hpImageMaxSize * (1.0f * _nowHp / _maxPlayerHP), _hpBarRedRtf.sizeDelta.y);
        //_nowHp / _maxPlayerHP;
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
            _isComboedCount = 0;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            _isGround = false;
        }
    }

    public void mutekiOn()
    {
        this.gameObject.layer = 6;
    }

    public void mutekiOff()
    {
        this.gameObject.layer = 0;
    }
}
