using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class hadoPrefub : MonoBehaviour
{
    [SerializeField] int _damage;
    [SerializeField] Vector3 _direction;
    [SerializeField] bool Air;
    [SerializeField] Transform _hitParPos;
    [SerializeField] GameObject _hitParticle;
    Rigidbody _rb;
    Vector3 _moveDirection;
    bool _player1Shot;
    public bool Player1Shot { set { _player1Shot = value; } }
    //string enemy = "Enemy";
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void SetVec(Vector3 vec)
    {
        _moveDirection = vec.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = _moveDirection * 10;
        transform.up = _rb.velocity;
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerDamageHit pdh = other.gameObject.GetComponent<PlayerDamageHit>();
        if (other.gameObject.tag == "Hado")
        {
            Destroy(this.gameObject);
        }
        if (_player1Shot && other.gameObject.tag == "Player2")
        {
            pdh.DamageHit(_damage, Air, _direction);
            Instantiate(_hitParticle).transform.position = _hitParPos.position;
            Destroy(gameObject);
        }
        if (!_player1Shot && other.gameObject.tag == "Player1")
        {
            pdh.DamageHit(_damage, Air, _direction);
            Instantiate(_hitParticle).transform.position = _hitParPos.position;
            Destroy(gameObject);
        }
    }
}
