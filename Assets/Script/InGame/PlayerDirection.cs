using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirection : MonoBehaviour
{
    [SerializeField] GameObject _enemyPlayer;
    Vector3 _playersDirection;
    public Vector3 PlayersDirection {  get { return _playersDirection; } }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _playersDirection = _enemyPlayer.transform.position - this.transform.position;
        _playersDirection = new Vector3(_playersDirection.x, this.transform.position.y, 0);
        transform.LookAt(_playersDirection);
    }
}
