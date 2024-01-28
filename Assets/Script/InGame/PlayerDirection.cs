using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerDirection : MonoBehaviour
{
    Vector3 _playersDirection;
    Vector3 _playerFo;
    public Vector3 PlayerFo {  get { return _playerFo; } }
    Vector3 _throwEndFo;
    public Vector3 ThrowEndFo { get { return _throwEndFo;} }
    PlayerAttacks _pa;
    PlayerData _pdata;
    bool _stop;
    public bool Stop { set { _stop = value; } }
    // Start is called before the first frame update
    void Start()
    {
        _pa = GetComponent<PlayerAttacks>();
        _pdata = GetComponent<PlayerData>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_stop)
        {
            if (gameObject.transform.position.x < _pdata.Enemy.transform.position.x)
            {
                _playersDirection = new Vector3(1, this.transform.position.y, 0);
            }
            else
            {
                _playersDirection = new Vector3(-1, this.transform.position.y, 0);
            }
            //_playersDirection = GetComponent<PlayerData>().Enemy.transform.position - this.transform.position;
            //_playersDirection = new Vector3(_playersDirection.x, this.transform.position.y, 0);
            if (_pdata.Flip)
            {
                _playersDirection.x *= -1;
            }
            Vector3 _playerLook = new Vector3(this.transform.position.x + _playersDirection.normalized.x, this.transform.position.y, this.transform.position.z + (GetComponent<PlayerData>().PlayerDirecRight ? -1 : 1));
            Debug.DrawLine(this.transform.position, _playerLook);
            if (!_pa.Attacking)
                transform.LookAt(_playerLook);
            _playerFo = _playersDirection;
            _playerFo.y = 0;
            _playerFo = _playerFo.normalized;
        }
    }
    public void ThrowFo()
    {
        _throwEndFo = _playerFo;
    }
}
