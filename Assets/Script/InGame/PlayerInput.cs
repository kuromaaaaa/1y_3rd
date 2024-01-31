using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] float _controllerDeadZone = 0.5f;
    [SerializeField] int _nyuryokuYuyo = 20;
    List<int> _allNyuryokuList = new List<int>();
    List<int> _simpleList = new List<int>();
    int _tenKey = 0;
    public int TenKey { get { return _tenKey; } }
    bool _1pPlayer;
    float _h, _v;
    bool _1P = false;

    bool _backStep;
    public bool BackStep { get { return _backStep; } set { _backStep = value; } }
    PlayerAttacks _pa;
    PlayerData _pdata;
    Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _pa = GetComponent<PlayerAttacks>();
        _pdata = GetComponent<PlayerData>();
        _anim = GetComponent<Animator>();
        if (this.gameObject.tag == "Player1")
            _1P = true;
    }

    // Update is called once per frame
    void Update()
    {

        bool jakuP;
        bool kyouK;
        if(_1P)
        {
            jakuP = Input.GetButton("c1_XorP");
            kyouK = Input.GetButton("c1_AorK");
        }
        else 
        { 
            jakuP = Input.GetButton("c2_XorP");
            kyouK = Input.GetButton("c2_AorK");
        }

        _1pPlayer = GetComponent<PlayerData>().PlayerDirecRight;
        _h = 0; _v = 0;
        _tenKey = InputTenKey();
        if (jakuP && kyouK)
        {
            _pa.PandK();
        }
        if (jakuP)
        {
            ListSimple();
            if(_simpleList.Count > 1)
                Debug.Log(string.Join(" ", _simpleList));
            if (_simpleList.Count > 2)
            {
                if (_simpleList.Count > 2 && _simpleList[_simpleList.Count - 1] == 3 && _simpleList[_simpleList.Count - 2] == 2 && _simpleList[_simpleList.Count - 3] == 6)
                {//¸—³Œ
                    _pa.syoryuHassei();
                }
            }
            if(_simpleList.Count > 3)
            {
                if (_simpleList[_simpleList.Count - 1] == 3 && _simpleList[_simpleList.Count - 2] == 2 && _simpleList[_simpleList.Count - 4] == 6)
                {
                    _pa.syoryuHassei();
                }
            }
            if(_simpleList.Count > 4)
            {
                if (_simpleList[_simpleList.Count - 2] == 3 && _simpleList[_simpleList.Count - 3] == 2 && _simpleList[_simpleList.Count - 5] == 6)
                {
                    _pa.syoryuHassei();
                }
            }
            if (!_pa.Attacking &&((_simpleList.Count > 2 && _simpleList[_simpleList.Count - 1] == 6 && _simpleList[_simpleList.Count - 2] == 3 && _simpleList[_simpleList.Count - 3] == 2)
                || (_simpleList.Count > 3 && _simpleList[_simpleList.Count - 2] == 6 && _simpleList[_simpleList.Count - 3] == 3 && _simpleList[_simpleList.Count - 4] == 2)))
            {//”g“®Œ
                _pa.hadoHassei();
            }
            /*
            else if ((_simpleList.Count > 2 && _simpleList[_simpleList.Count - 1] == 6 && _simpleList[_simpleList.Count - 2] == 3 && _simpleList[_simpleList.Count - 3] == 2)
            || (_simpleList.Count > 3 && _simpleList[_simpleList.Count - 2] == 6 && _simpleList[_simpleList.Count - 3] == 3 && _simpleList[_simpleList.Count - 4] == 2))
            {//”g“®Œ
                _pa.hadoHassei();
            }
            */
            else if(!_pa.Attacking)
            {
                _pa.pressP(_tenKey);
            }
            _allNyuryokuList.Clear();
        }

        if (kyouK)
        {
            _pa.pressK(_tenKey);
        }

        if(TenKey == 4 && !_pa.Attacking)
        {
            ListSimple();
            if(_simpleList.Count > 3)
            {
                if (_simpleList[_simpleList.Count - 1] == 4 && _simpleList[_simpleList.Count - 2] == 5 
                    && _simpleList[_simpleList.Count - 3] == 4 && _pdata.IsGround)
                {
                    _backStep = true;
                    _pa.Attacking = true;
                }
            }
        }
        _anim.SetBool("BackStep", _backStep);
    }

    void FixedUpdate()
    {
        _allNyuryokuList.Add(_tenKey);
        if (_allNyuryokuList.Count >= _nyuryokuYuyo)
        {
            _allNyuryokuList.RemoveAt(0);
        }
    }

    int InputTenKey()
    {
        if (_1P)
        {
            _h += Input.GetAxisRaw("c1_axisX") > _controllerDeadZone ? 1 : 0;
            _h += Input.GetAxisRaw("c1_axisX") < _controllerDeadZone * -1 ? -1 : 0;
            _v += Input.GetAxisRaw("c1_axisY") > _controllerDeadZone ? 1 : 0;
            _v += Input.GetAxisRaw("c1_axisY") < _controllerDeadZone * -1 ? -1 : 0;
        }
        else
        {
            _h += Input.GetAxisRaw("c2_axisX") > _controllerDeadZone ? 1 : 0;
            _h += Input.GetAxisRaw("c2_axisX") < _controllerDeadZone * -1 ? -1 : 0;
            _v += Input.GetAxisRaw("c2_axisY") > _controllerDeadZone ? 1 : 0;
            _v += Input.GetAxisRaw("c2_axisY") < _controllerDeadZone * -1 ? -1 : 0;
        }

        if (_1pPlayer)
        {
            switch (_v)
            {
                case 1:
                {
                    switch (_h)
                    {
                        case -1: return 7;
                        case 0: return 8;
                        case 1: return 9;
                    }
                    break;
                }
                case 0:
                {
                    switch (_h)
                    {
                        case -1: return 4;
                        case 0: return 5;
                        case 1: return 6;
                    }
                    break;
                }
                case -1:
                {
                    switch (_h)
                    {
                        case -1: return 1;
                        case 0: return 2;
                        case 1: return 3;
                    }
                    break;
                }
            }
        }
        else
        {
            switch (_v)
            {
                case 1:
                {
                    switch (_h)
                    {
                        case -1: return 9;
                        case 0: return 8;
                        case 1: return 7;
                    }
                    break;
                }
                case 0:
                {
                    switch (_h)
                    {
                        case -1: return 6;
                        case 0: return 5;
                        case 1: return 4;
                    }
                    break;
                }
                case -1:
                {
                    switch (_h)
                    {
                        case -1: return 3;
                        case 0: return 2;
                        case 1: return 1;
                    }
                    break;
                }
            }
        }
        return 0;
    }

    void ListSimple()
    {
        _simpleList = _allNyuryokuList;
        for (int i = 0; i < _simpleList.Count - 1;)
        {
            if (_simpleList[i] == _simpleList[i + 1])
            {
                _simpleList.RemoveAt(i);
            }
            else
            {
                i++;
            }
        }

    }
}
