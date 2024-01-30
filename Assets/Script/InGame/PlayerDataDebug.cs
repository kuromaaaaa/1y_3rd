using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataDebug : MonoBehaviour
{
    [SerializeField] bool attacking;
    [SerializeField] bool isGround;
    [SerializeField] bool damaging;
    [SerializeField] int tenkey;
    [SerializeField] string direction;
    [SerializeField] bool isjamp;

    PlayerMove _pm;
    PlayerInput _pi;
    PlayerData _pdata;
    PlayerAttacks _pa;

    // Start is called before the first frame update
    void Start()
    {
        _pm = GetComponent<PlayerMove>();
        _pi = GetComponent<PlayerInput>();
        _pdata = GetComponent<PlayerData>();
        _pa = GetComponent<PlayerAttacks>();
    }

    // Update is called once per frame
    void Update()
    {
        attacking = _pa.Attacking;
        isGround = _pdata.IsGround;
        damaging = _pdata.Damaging;
        tenkey = _pi.TenKey;
        isjamp = _pm.IsJump;
        if (_pdata.PlayerDirecRight)
            direction = "Å®";
        else direction = "Å©";
    }
}
