using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CenterPlayers : MonoBehaviour
{
    [SerializeField] GameObject _player1;
    [SerializeField] GameObject _player2;
    [SerializeField] float _camPosY = 1;
    [SerializeField] float _leastCamPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 p1t = _player1.transform.position;
        Vector3 p2t = _player2.transform.position;
        float distance = p1t.x < p2t.x ? p2t.x - p1t.x : p1t.x - p2t.x ;
        Vector3 Vec1to2 = p2t - p1t;
        Vec1to2 = new Vector3(Vec1to2.x, 0, 0);
        transform.position = p1t + (Vec1to2.normalized) * distance/2;
        transform.position = new Vector3(transform.position.x, _camPosY, transform.position.z);
        if(distance < _leastCamPos)
            distance = _leastCamPos;
        Vector3 CamPos = gameObject.transform.position - new Vector3(0, 0, distance);
        Camera.main.transform.position = CamPos;
    }
}