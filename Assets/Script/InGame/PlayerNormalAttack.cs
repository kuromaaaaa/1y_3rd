using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNormalAttack : MonoBehaviour
{
    [SerializeField] int _SeriJizoku = 2;
    [SerializeField] int _damage = 0;
    [SerializeField] bool _air;
    [SerializeField] Vector3 _huttobi;
    int _jizoku;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        _jizoku = _SeriJizoku;
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
        other.gameObject.GetComponent<PlayerDamageHit>().DamageHit(_damage, _air, _huttobi);
    }
}
