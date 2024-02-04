using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleRndUnityChan : MonoBehaviour
{
    [SerializeField] float _animCoolTime;
    float _timeCount = 0;
    int _randomInt = 0;
    Animator _anim;
    [SerializeField] GameObject _particle;
    [SerializeField] List<Transform> _trList = new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _randomInt = 0;
        _timeCount += Time.deltaTime;
        if(_timeCount > _animCoolTime)
        {
            _randomInt = Random.Range(1, 4);
            _timeCount = 0;
            _animCoolTime = Random.Range(2, 5);
        }
        _anim.SetInteger("rnd", _randomInt);
    }

    void particle(int num)
    {
        Instantiate(_particle).transform.position = _trList[num].position;
    }
}
