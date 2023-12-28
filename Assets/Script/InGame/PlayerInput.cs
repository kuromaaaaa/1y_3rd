using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] GameObject _enemyPlayer;
    [SerializeField] float _controllerDeadZone = 0.5f;
    [SerializeField] int _nyuryokuYuyo = 20;
    List<int> _allNyuryokuList = new List<int>();
    List<int> _simpleList = new List<int>();
    int _tenKey = 0;
    public int TenKey { get { return _tenKey; } }
    bool _1pPlayer;
    float _h, _v;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _1pPlayer = (gameObject.transform.position.x < _enemyPlayer.transform.position.x);
        _h = 0; _v = 0;
        _tenKey = InputTenKey();
        if (Input.GetButtonDown("Fire1"))
        {
            Click();
            GetComponent<PlayerAttacks>().hado(_simpleList);
            _allNyuryokuList.Clear();
        }
    }

    void FixedUpdate()
    {
        _allNyuryokuList.Add(_tenKey);
        if (_allNyuryokuList.Count >= _nyuryokuYuyo)
        {
            _allNyuryokuList.RemoveAt(0);
        }
        Debug.Log(string.Join(" ", _allNyuryokuList));
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
