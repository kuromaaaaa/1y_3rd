using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttacks : MonoBehaviour
{
    [SerializeField] GameObject _hadoPrefub;
    [SerializeField] GameObject _5Kcolli;
    [SerializeField] GameObject _2Kcolli;
    [SerializeField] GameObject _5Pcolli;
    [SerializeField] GameObject _2Pcolli;
    bool _hado = false;
    bool _5K = false;
    bool _2K = false;
    bool _5P = false;
    bool _2P = false;
    bool _attacking = false;
    public bool Attacking { get { return _attacking; } }
    Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _anim.SetBool("HADO", _hado);
        _anim.SetBool("5K", _5K);
        _anim.SetBool("2K", _2K);
        _anim.SetBool("5P", _5P);
        _anim.SetBool("2P", _2P);
    }

    public void hadoHassei()
    {
        _hado = true;
        _attacking = true;
    }

    public void pressP(int tenKey)
    {
        if (tenKey == 1 || tenKey == 2 || tenKey == 3)
        {
            _2P = true;
            _attacking = true;
        }
        else
        {
            _5P = true;
            _attacking = true;
        }
    }
    public void pressK(int tenKey)
    {
        if(tenKey == 1 || tenKey == 2 || tenKey == 3)
        {
            _2K = true;
            _attacking = true;
        }
        else
        {
            _5K = true;
            _attacking = true;
        }
    }

    public void normal5P()
    {
        _5Pcolli.SetActive(true);
    }

    public void normal2P()
    {
        _2Pcolli.SetActive(true);
    }

    public void normal5K()
    {
        _5Kcolli.SetActive(true);
    }

    public void normal2K()
    {
        _2Kcolli.SetActive(true);
    }


    public void hado()
    {
        Debug.Log("îgìÆåù");
        GameObject tama = Instantiate(_hadoPrefub);
        tama.transform.position = this.transform.position;
        Vector3 tamaVec = GetComponent<PlayerDirection>().PlayerFo;
        tama.GetComponent<hadoPrefub>().SetVec(tamaVec);
        if(this.tag == "Player1")
        {
            tama.GetComponent<hadoPrefub>().Player1Shot = true;
        }
        else
        {
            tama.GetComponent<hadoPrefub>().Player1Shot = false;
        }
    }

    public void animEnd()
    {
        _hado = false;
        _attacking = false;
        _5K = false;
        _2K = false;
        _5P = false;
        _2P = false;
    }

}
