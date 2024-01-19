using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float _movePower = 5;
    Rigidbody _rb;
    PlayerInput _input;
    PlayerData _pd;
    Animator _anim;

    bool _moveForward;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _input = GetComponent<PlayerInput>();
        _pd = GetComponent<PlayerData>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = GetComponent<PlayerDirection>().PlayerFo;
        //Debug.Log(_input.TenKey);
        if(_input.TenKey == 6 && !_pd.Damaging)
        {
            _rb.velocity = new Vector3(direction.x * _movePower, _rb.velocity.y, 0);
            _moveForward = true;
        }
        else if(_input.TenKey == 4 && !_pd.Damaging)
        {
            _rb.velocity = new Vector3(direction.x * _movePower * -1, _rb.velocity.y, 0);
        }
        else if(!_pd.Damaging)
        {
            _rb.velocity = new Vector3(0, _rb.velocity.y, 0);
            _moveForward = false;
        }
        if(_anim)
        {
            _anim.SetBool("MoveForward", _moveForward);
        }
    }
    void OnAnimatorMove()
    {
        //transform.position = GetComponent<Animator>().rootPosition;
    }
}
