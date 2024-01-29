using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrow : MonoBehaviour
{
    [SerializeField] int _CollisionJizoku = 2;
    [SerializeField, Tooltip("投げ開始時の位置調整")] float _throwStartDistance;
    int _jizoku;
    bool _hit;
    GameManager _gm;
    private void OnEnable()
    {
        _hit = false;
        _jizoku = _CollisionJizoku;
    }
    // Start is called before the first frame update
    void Start()
    {
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        _jizoku--;
        if (_jizoku == 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<PlayerData>())
        {
            _hit = true;
            other.gameObject.GetComponent<PlayerDirection>().Stop = true;
            other.GetComponent<Animator>().SetTrigger("thrown");
            transform.parent.gameObject.GetComponent<Animator>().SetTrigger("triggerThrow2");
            other.GetComponent<CapsuleCollider>().enabled = false;
            other.GetComponent<Rigidbody>().isKinematic = true;
            other.transform.position = other.transform.position + 
                other.GetComponent<PlayerDirection>().PlayerFo * _throwStartDistance;
            transform.parent.gameObject.GetComponent<PlayerDirection>().ThrowFo();
            _gm.GMthrow(transform.parent.gameObject.GetComponent<PlayerDirection>().PlayerFo, true);
            //this.gameObject.GetComponent<Animator>().SetTrigger("triggerThrow");
        }
    }
    private void OnDisable()
    {
        Debug.Log(_hit);
        if (!_hit)
        {
            _gm.GMthrow(transform.parent.gameObject.GetComponent<PlayerDirection>().PlayerFo, false);
        }
    }
}
