using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    [SerializeField] float _destroyTime = 1;
    float _timerCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timerCount += Time.deltaTime;
        if(_timerCount > _destroyTime)
        {
            Destroy(gameObject);
        }
    }
}
