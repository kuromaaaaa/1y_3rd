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

    PlayerAttacks _pa;
    // Start is called before the first frame update
    void Start()
    {
        _pa = GetComponent<PlayerAttacks>();
    }

    // Update is called once per frame
    void Update()
    {
        bool jakuP = Input.GetButton("Fire1");
        bool kyouK = Input.GetButton("Fire2");
        _1pPlayer = (gameObject.transform.position.x < GetComponent<PlayerData>().Enemy.transform.position.x);
        _h = 0; _v = 0;
        _tenKey = InputTenKey();
        if (jakuP)
        {
            Click(); 
            if ((_simpleList.Count > 2 && _simpleList[_simpleList.Count - 1] == 6 && _simpleList[_simpleList.Count - 2] == 3 && _simpleList[_simpleList.Count - 3] == 2)
            || (_simpleList.Count > 3 && _simpleList[_simpleList.Count - 2] == 6 && _simpleList[_simpleList.Count - 3] == 3 && _simpleList[_simpleList.Count - 4] == 2))
            {
                _pa.hadoHassei();
            }
            else
            {
                _pa.pressP(_tenKey);
            }
            _allNyuryokuList.Clear();
        }
        if (kyouK)
        {
            _pa.pressK(_tenKey);
        }
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
        _h += Input.GetAxisRaw("Horizontal") > _controllerDeadZone ? 1 : 0;
        _h += Input.GetAxisRaw("Horizontal") < _controllerDeadZone * -1 ? -1 : 0;
        _v += Input.GetAxisRaw("Vertical") > _controllerDeadZone ? 1 : 0;
        _v += Input.GetAxisRaw("Vertical") < _controllerDeadZone * -1 ? -1 : 0;

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

    void Click()
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
