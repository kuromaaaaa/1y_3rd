using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookIK : MonoBehaviour
{
    Animator _anim;
    GameManager _gm;
    [SerializeField] Transform _target;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnAnimatorIK(int layerIndex)
    {
        if (!GetComponent<PlayerAttacks>().Syoryu && !_gm.GameOver)
        {
            _anim.SetLookAtWeight(1);
            _anim.SetLookAtPosition(_target.position);
        }
    }
}
