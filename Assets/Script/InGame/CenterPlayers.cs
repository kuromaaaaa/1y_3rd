using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CenterPlayers : MonoBehaviour
{
    
    GameObject _player1;
    GameObject _player2;
    [SerializeField] float _camPosY = 1;
    [SerializeField] float _minCamPos;
    [SerializeField] float _maxCamPos;

    [SerializeField] int _throwCamFlame = 60;
    int _nowFlame = 0;
    [SerializeField] float _throwEndDistance = 1;
    Vector3 _moveParFlame;
    bool _throwing = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject GM = GameObject.Find("GameManager");
        _player1 = GM.GetComponent<GameManager>().PlayerArr[0];
        _player2 = GM.GetComponent<GameManager>().PlayerArr[1];
    }

    public void throwCam(Vector3 direc)
    {
        _moveParFlame = (direc * _throwEndDistance) / _throwCamFlame;
        Debug.Log(_moveParFlame);
        _nowFlame = 0;
        _throwing = true;
    }

    private void FixedUpdate()
    {
        if(_throwing)
        {
            _nowFlame++;
            this.transform.position += _moveParFlame;
            Camera.main.transform.position += _moveParFlame;
            if (_nowFlame > _throwCamFlame)
            {
                _throwing = false;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!_throwing)
        {
            Vector3 p1t = _player1.transform.position;
            Vector3 p2t = _player2.transform.position;
            float distance = p1t.x < p2t.x ? p2t.x - p1t.x : p1t.x - p2t.x;
            Vector3 Vec1to2 = p2t - p1t;
            Vec1to2 = new Vector3(Vec1to2.x, 0, 0);
            transform.position = p1t + (Vec1to2.normalized) * distance / 2;
            transform.position = new Vector3(transform.position.x, _camPosY, transform.position.z);
            if (distance < _minCamPos)
                distance = _minCamPos;
            if (distance > _maxCamPos)
                distance = _maxCamPos;
            Vector3 CamPos = gameObject.transform.position - new Vector3(0, 0, distance);
            Camera.main.transform.position = CamPos;
        }
    }
}