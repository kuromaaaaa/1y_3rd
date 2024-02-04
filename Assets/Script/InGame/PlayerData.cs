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
    Animator _anim;
    PlayerParticles _pp;
    AudioSource _as;
    PlayerDirection _pdirec;
    Rigidbody _rb;
    ResultScoreDDOL _rsDDOL;
    public PlayerParticles PP { get { return _pp; } set{ _pp = value; } }

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
    int _comboedCount = 0;
    public int ComboCount { set { _comboedCount = value; } get { return _comboedCount; } }
    bool _isGround = false;
    public bool IsGround { get { return _isGround; } }
    bool _collisionHitGround = false;
    public bool CollisionHitGround { set { _collisionHitGround = value; } get { return _collisionHitGround; } }
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
        _anim = GetComponent<Animator>();
        _as = GetComponent<AudioSource>();
        _pdirec = GetComponent<PlayerDirection>();
        _rb = GetComponent<Rigidbody>();
        _rsDDOL = GameObject.Find("resultScore").GetComponent<ResultScoreDDOL>();
        if (_player1)
        {
            _rsDDOL.P1HP = _maxPlayerHP;
        }
        else
        {
            _rsDDOL.P2HP = _maxPlayerHP;
        }
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
        _hpBarBlueRtf.sizeDelta = new Vector2(_hpImageMaxSize * (1.0f * _nowHp / _maxPlayerHP),_hpBarBlueRtf.sizeDelta.y);
        if(!_damaging || _nowHp <= 0)
        _hpBarRedRtf.sizeDelta = new Vector2(_hpImageMaxSize * (1.0f * _nowHp / _maxPlayerHP), _hpBarRedRtf.sizeDelta.y);
        //_nowHp / _maxPlayerHP;
        _anim.SetBool("IsGround",_isGround);
        _anim.SetBool("CollisionHitGround", _collisionHitGround);
    }

    public void MinusHP(int minus)
    {
        bool zeroUp = (_nowHp > 0 ? true:false );
        _nowHp -= minus;
        if(_player1)
        {
            _rsDDOL.P1HP = _nowHp;
        }
        else
        {
            _rsDDOL.P2HP = _nowHp;
        }
        if (_nowHp <= 0 && zeroUp)
        {
            _gm.GetComponent<GameManager>().lose(gameObject.tag);
            _as.Play();
            _anim.SetTrigger("DEAD");
            _rb.velocity = Vector3.zero;
            _rb.AddForce(new Vector3(_pdirec.PlayerFo.x * -1,1,0));
            Time.timeScale = 0.5f;
        }
    }

    public void tyakuti()
    {
        _isGround = true;
        _damaging = false;
        _comboedCount = 0;
    }

    public void isGround_false()
    {
        _isGround = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            _collisionHitGround = true;
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
