using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirection : MonoBehaviour
{
    Vector3 _playersDirection;
    Vector3 _playerFo;
    public Vector3 PlayerFo {  get { return _playerFo; } }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.x < GetComponent<PlayerData>().Enemy.transform.position.x)
        {
            _playersDirection = new Vector3(1, this.transform.position.y, 0);
        }
        else
        {
            _playersDirection = new Vector3(-1, this.transform.position.y, 0);
        }
        //_playersDirection = GetComponent<PlayerData>().Enemy.transform.position - this.transform.position;
        //_playersDirection = new Vector3(_playersDirection.x, this.transform.position.y, 0);
        Vector3 _playerLook = new Vector3(this.transform.position.x + _playersDirection.normalized.x, this.transform.position.y, this.transform.position.z + (GetComponent<PlayerData>().PlayerDirecRight ? -1:1));
        Debug.DrawLine(this.transform.position, _playerLook);
        transform.LookAt(_playerLook);
        _playerFo = _playersDirection;
        _playerFo.y = 0;
        _playerFo = _playerFo.normalized;
    }
}
