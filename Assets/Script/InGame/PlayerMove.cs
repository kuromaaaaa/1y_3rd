using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float _movePower = 5;
    [SerializeField] float _backSpeed = 4;
    [SerializeField] float _jumpPower = 1;
    [SerializeField] float _JumpHoriPower = 1;
    Rigidbody _rb;
    PlayerInput _input;
    PlayerData _pd;
    PlayerAttacks _pa;
    Animator _anim;

    bool _isJumping;
    public bool IsJump { get { return _isJumping; } }
    bool _isJumpingAir = false;
    Vector3 _jumpDirec;

    bool _moveForward;
    bool _moveBack;
    bool _crouch;
    Vector3 _direction;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _input = GetComponent<PlayerInput>();
        _pd = GetComponent<PlayerData>();
        _anim = GetComponent<Animator>();
        _pa = GetComponent<PlayerAttacks>();
    }

    // Update is called once per frame
    void Update()
    {
        _direction = GetComponent<PlayerDirection>().PlayerFo;
        //Debug.Log(_input.TenKey);
        if(_input.TenKey == 6 && !_pd.Damaging && !_pa.Attacking && !_isJumping)
        {
            _rb.velocity = new Vector3(_direction.x * _movePower, _rb.velocity.y, 0);
            _moveForward = true;
            _moveBack = false;
            _crouch = false;
        }
        else if(_input.TenKey == 4 && !_pd.Damaging && !_pa.Attacking && !_isJumping)
        {
            _rb.velocity = new Vector3(_direction.x * _backSpeed * -1, _rb.velocity.y, 0);
            _moveBack = true;
            _moveForward = false;
            _crouch = false;
        }
        else if((_input.TenKey == 1 || _input.TenKey == 2 || _input.TenKey == 3 ) 
                    && !_pd.Damaging && !_pa.Attacking && !_isJumping)
        {
            _rb.velocity = new Vector3(0, _rb.velocity.y, 0);
            _crouch = true;
            _moveBack = false;
            _moveForward = false;
        }
        else if(_crouch && !(_input.TenKey == 1 || _input.TenKey == 2 || _input.TenKey == 3))
        {
            _crouch = false;
        }
        else if(!_pd.Damaging && !_pa.SyoryuMove && !_isJumping)
        {
            _rb.velocity = new Vector3(0, _rb.velocity.y, 0);
            _moveForward = false;
            _moveBack = false;
            //_crouch = false;
        }
        if((_input.TenKey == 7 || _input.TenKey == 8 || _input.TenKey == 9) 
            && !_pd.Damaging && !_pa.Attacking && _pd.IsGround && !_isJumping)
        {
            _anim.SetTrigger("Jumping");
            _isJumping = true;
            Debug.Log("Jump");
        }
        if(_anim)
        {
            _anim.SetBool("MoveForward", _moveForward);
            _anim.SetBool("MoveBack", _moveBack);
            _anim.SetBool("Crouch", _crouch);
        }

        if(_isJumpingAir)
        {
            _rb.velocity = new Vector3(_jumpDirec.x * _JumpHoriPower,_rb.velocity.y ,0);
        }
    }
    
    public void jumpStartDistance()
    {
        _rb.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
        if (_input.TenKey % 3 == 0)//前ジャンプ
        {
            _jumpDirec = _direction;
        }
        else if (_input.TenKey % 3 == 2)//垂直
        {
            _jumpDirec = Vector3.zero;
        }
        else //後ろジャンプ
        {
            _jumpDirec = _direction * -1;
        }
        _isJumpingAir = true;
    }

    public void JumpEnd()
    {
        _isJumping = false;
        _isJumpingAir = false;
    }

    void OnAnimatorMove()
    {
        //transform.position = GetComponent<Animator>().rootPosition;
    }
}
