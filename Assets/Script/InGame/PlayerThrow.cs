using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrow : MonoBehaviour
{
    [SerializeField] int _CollisionJizoku = 2;
    [SerializeField, Tooltip("ìäÇ∞äJénéûÇÃà íuí≤êÆ")] float _throwStartDistance;
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
            PlayerData pData = other.GetComponent<PlayerData>();
            PlayerDirection pDirec = other.GetComponent<PlayerDirection>();
            if (pData.IsGround && !pData.Damaging)
            {
                _hit = true;
                pDirec.Stop = true;
                other.GetComponent<Animator>().SetTrigger("thrown");
                transform.parent.gameObject.GetComponent<Animator>().SetTrigger("triggerThrow2");
                other.GetComponent<CapsuleCollider>().enabled = false;
                other.GetComponent<Rigidbody>().isKinematic = true;
                other.transform.position = other.transform.position +
                    pDirec.PlayerFo * _throwStartDistance;
                transform.parent.gameObject.GetComponent<PlayerDirection>().ThrowFo();
                _gm.GMthrow(transform.parent.gameObject.GetComponent<PlayerDirection>().PlayerFo, true ,this.transform.position);
                //this.gameObject.GetComponent<Animator>().SetTrigger("triggerThrow");
            }
        }
    }
    private void OnDisable()
    {
        if (!_hit)
        {
            _gm.GMthrow(transform.parent.gameObject.GetComponent<PlayerDirection>().PlayerFo, false,this.transform.position);
        }
    }
}
