using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageHit : MonoBehaviour
{
    Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DamageHit(int damage, bool air, Vector3 direc)
    {
        int tenkey = GetComponent<PlayerInput>().TenKey;
        if(GetComponent<PlayerData>().PlayerDirecRight)
        {
            direc = new Vector3(direc.x * -1, direc.y, direc.z);
        }
        if((tenkey == 4 || tenkey == 1) && !GetComponent<PlayerData>().Damaging)
        {
            _rb.AddForce(GetComponent<PlayerDirection>().PlayerFo * -1);
        }
        else if(air)
        {
            _rb.AddForce(direc,ForceMode.Impulse);
            GetComponent<PlayerData>().MinusHP(damage);
            GetComponent<PlayerData>().Damaging = true;
        }
        else
        {
            _rb.AddForce(GetComponent<PlayerDirection>().PlayerFo * -1,ForceMode.Impulse);
            GetComponent<PlayerData>().MinusHP(damage);
            GetComponent<PlayerData>().Damaging = true;
        }
    }
}
