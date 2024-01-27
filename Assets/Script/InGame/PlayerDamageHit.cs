using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageHit : MonoBehaviour
{
    Rigidbody _rb;
    PlayerData _pdata;
    PlayerDirection _pdirec;
    [SerializeField, Tooltip("“Š‚°Œã‚ÌˆÊ’u")] float _throwEndDistance;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _pdata = GetComponent<PlayerData>();
        _pdirec = GetComponent<PlayerDirection>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DamageHit(int damage, bool air, Vector3 direc)
    {
        _rb.velocity = Vector3.zero;
        int tenkey = GetComponent<PlayerInput>().TenKey;
        if(_pdata.PlayerDirecRight)
        {
            direc = new Vector3(direc.x * -1, direc.y, direc.z);
        }
        if((tenkey == 4 || tenkey == 1) && !_pdata.Damaging)
        {
            _rb.AddForce(_pdirec.PlayerFo * -1);
        }
        else if(air)
        {
            _rb.AddForce(direc,ForceMode.Impulse);
            _pdata.MinusHP(damage);
            _pdata.Damaging = true;
            _pdata.IsComboCount++;
            Debug.Log(_pdata.IsComboCount);
        }
        else
        {
            _rb.AddForce(_pdirec.PlayerFo * -1,ForceMode.Impulse);
            _pdata.MinusHP(damage);
            _pdata.Damaging = true;
            _pdata.IsComboCount++;
            Debug.Log(_pdata.IsComboCount);
        }
    }

    public void throwEnd() 
    { 
        _rb.isKinematic = false;
        GetComponent<CapsuleCollider>().enabled = true;
        this.transform.position = this.transform.position + _pdirec.PlayerFo * _throwEndDistance;
    }
}
