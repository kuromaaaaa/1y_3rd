using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UntyChanMethod : MonoBehaviour
{
    [SerializeField] GameObject _redParticle;
    [SerializeField] GameObject _kamisunaParticle;
    [SerializeField] List<Transform> _transformList = new List<Transform>();
    GameObject _kami1;
    GameObject _kami2;
    // Start is called before the first frame update
    Animator _anim;
    private void Start()
    {
        _anim = GetComponent<Animator>();
    }
    void ParticleInstantiate(int num)
    {
        if(num < 2)
        {
            Instantiate(_redParticle).transform.position = _transformList[num].position;
        }
        else if(num == 2)
        {
            _kami1 = Instantiate(_kamisunaParticle);
            _kami1.transform.position = _transformList[num].position;
        }
        else 
        { 
            _kami2 = Instantiate(_kamisunaParticle);
            _kami2.transform.position = _transformList[num].position;
        }
    }

    void TimeScaleZero()
    {
        Time.timeScale = 0;
    }

    void KamisunaStop()
    {
        _kami1.GetComponent<ParticleSystem>().Pause();
        _kami2.GetComponent<ParticleSystem>().Pause();
    }

    void AnimStop()
    {
        _anim.speed = 0;
    }
}
