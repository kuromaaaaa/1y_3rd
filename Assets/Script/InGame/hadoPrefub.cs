using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class hadoPrefub : MonoBehaviour
{
    Rigidbody _rb;
    Vector3 _moveDirection;
    string enemy = "Enemy";
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void SetVec(Vector3 vec)
    {
        _moveDirection = vec.normalized;
        Debug.Log(vec);
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = _moveDirection * 10;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == enemy)
        {
            other.gameObject.GetComponent<PlayerDamageHit>().DamageHit(60, true, new Vector3(10, 10, 0));
            Destroy(gameObject);
        }
    }
}
