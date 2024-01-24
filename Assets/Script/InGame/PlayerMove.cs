using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float _movePower = 5;
    [SerializeField] float _backSpeed = 4;
    Rigidbody _rb;
    PlayerInput _input;
    PlayerData _pd;
    PlayerAttacks _pa;
    Animator _anim;

    bool _moveForward;
    bool _moveBack;
    bool _crouch;
    
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
        Vector3 direction = GetComponent<PlayerDirection>().PlayerFo;
        //Debug.Log(_input.TenKey);
        if(_input.TenKey == 6 && !_pd.Damaging && !_pa.Attacking)
        {
            _rb.velocity = new Vector3(direction.x * _movePower, _rb.velocity.y, 0);
            _moveForward = true;
            _moveBack = false;
            _crouch = false;
        }
        else if(_input.TenKey == 4 && !_pd.Damaging && !_pa.Attacking)
        {
            _rb.velocity = new Vector3(direction.x * _backSpeed * -1, _rb.velocity.y, 0);
            _moveBack = true;
            _moveForward = false;
            _crouch = false;
        }
        else if((_input.TenKey == 1 || _input.TenKey == 2 || _input.TenKey == 3 ) && !_pd.Damaging && !_pa.Attacking)
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
        else if(!_pd.Damaging)
        {
            _rb.velocity = new Vector3(0, _rb.velocity.y, 0);
            _moveForward = false;
            _moveBack = false;
            //_crouch = false;
        }
        if(_anim)
        {
            _anim.SetBool("MoveForward", _moveForward);
            _anim.SetBool("MoveBack", _moveBack);
            _anim.SetBool("Crouch", _crouch);
        }
    }
    void OnAnimatorMove()
    {
        //transform.position = GetComponent<Animator>().rootPosition;
    }
}
