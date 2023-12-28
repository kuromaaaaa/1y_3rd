using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirection : MonoBehaviour
{
    [SerializeField] GameObject _enemyPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = _enemyPlayer.transform.position;
        direction = new Vector3(direction.x, this.transform.position.y, 0);
        transform.LookAt(direction);
    }
}
