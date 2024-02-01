using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageHit : MonoBehaviour
{
    Rigidbody _rb;
    PlayerData _pdata;
    PlayerDirection _pdirec;
    Animator _anim;
    [SerializeField, Tooltip("“Š‚°Œã‚ÌˆÊ’u")] float _throwEndDistance;
    [SerializeField] int _throwDamage;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _pdata = GetComponent<PlayerData>();
        _pdirec = GetComponent<PlayerDirection>();
        _anim = GetComponent<Animator>();
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
        if((tenkey == 4 || tenkey == 1) && !_pdata.Damaging && _pdata.IsGround)
        {
            _rb.AddForce(_pdirec.PlayerFo * -1);
            _anim.SetTrigger("Guard");
        }
        else if(air)
        {
            _pdata.CollisionHitGround = false;
            _anim.SetTrigger("DamageAir");
            _rb.AddForce(direc,ForceMode.Impulse);
            _pdata.MinusHP(damage);
            _pdata.Damaging = true;
            _pdata.IsComboCount++;
            Debug.Log(_pdata.IsComboCount);
        }
        else
        {
            _anim.SetTrigger("DamageGrouond");
            _rb.AddForce(_pdirec.PlayerFo * -1,ForceMode.Impulse);
            _pdata.MinusHP(damage);
            _pdata.Damaging = true;
            _pdata.IsComboCount++;
            Debug.Log(_pdata.IsComboCount);
        }
    }

    public void thrownEnd() 
    { 
        _rb.isKinematic = false;
        GetComponent<CapsuleCollider>().enabled = true;
        _pdirec.Stop = false;
        this.transform.position = this.transform.position + _pdirec.PlayerFo * _throwEndDistance;
        _pdata.Enemy.GetComponent<PlayerData>().Flip = false;
    }

    public void thrownDamage()
    {
        _pdata.MinusHP(_throwDamage);
    }
}
