using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookIK : MonoBehaviour
{
    Animator _anim;
    [SerializeField] Transform _target;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnAnimatorIK(int layerIndex)
    {
        _anim.SetLookAtWeight(1);
        _anim.SetLookAtPosition(_target.position);
    }
}
