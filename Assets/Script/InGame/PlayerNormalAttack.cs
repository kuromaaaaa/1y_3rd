using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerNormalAttack : MonoBehaviour
{
    [SerializeField] int _CollisionJizoku = 2;
    [SerializeField] int _damage = 0;
    [SerializeField] bool _air;
    [SerializeField] Vector3 _huttobi;
    AudioSource _as;
    int _jizoku;
    // Start is called before the first frame update
    void Start()
    {
        _as = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _jizoku = _CollisionJizoku;
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
        if (other.gameObject.GetComponent<PlayerDamageHit>())
        {
            other.gameObject.GetComponent<PlayerDamageHit>().DamageHit(_damage, _air, _huttobi);
            Debug.Log("hit");
            if (_as)
            {
                _as.Play();
            }
        }
    }
}
