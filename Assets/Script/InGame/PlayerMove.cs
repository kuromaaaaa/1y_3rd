using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float _movePower = 5;
    Rigidbody _rb;
    PlayerInput _input;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _input = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = GetComponent<PlayerDirection>().PlayersDirection;
        direction.y = 0;
        //Debug.Log(_input.TenKey);
        if(_input.TenKey == 6)
        {
            _rb.velocity = direction.normalized * _movePower;
        }
        else if(_input.TenKey == 4)
        {
            _rb.velocity = direction.normalized * _movePower * -1;
        }
        else
        {
            _rb.velocity = new Vector3(0, _rb.velocity.y, 0);
        }
    }
}
