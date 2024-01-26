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
    [SerializeField] GameObject _syoryuColli;
    PlayerData _pdata;
    PlayerDirection _pdire;
    Rigidbody _rb;
    bool _syoryu = false;
    bool _syoryuMove = false;
    public bool SyoryuMove { get { return _syoryuMove; } }
    public bool Syoryu { get { return _syoryu; } }
    bool _hado = false;
    bool _5K = false;
    bool _2K = false;
    bool _5P = false;
    bool _2P = false;
    bool _attacking = false;
    bool _nageKanou = false;
    public bool Attacking { get { return _attacking; } }
    Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _pdata = GetComponent<PlayerData>();
        _pdire = GetComponent<PlayerDirection>();
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _anim.SetBool("SYORYU", _syoryu);
        _anim.SetBool("HADO", _hado);
        _anim.SetBool("5K", _5K);
        _anim.SetBool("2K", _2K);
        _anim.SetBool("5P", _5P);
        _anim.SetBool("2P", _2P);
        if(_syoryuMove)
        {
            _rb.velocity = _pdire.PlayerFo * 2f;
        }
    }

    public void syoryuHassei()
    {
        if (!_attacking && _pdata.IsGround)
        {
            Debug.Log("è∏ó≥");
            _anim.SetTrigger("triggerSyoryu");
            _syoryu = true;
            _attacking = true;
            _syoryuMove = true;
        }
    }

    public void syoryuHitColli() 
    { 
        _syoryuColli.SetActive(true);
    }

    public void syoryuMoving()
    {
        _syoryuMove = false;
    }

    public void hadoHassei()
    {
        if (!_attacking && _pdata.IsGround)
        {
            Debug.Log("îgìÆ");
            _anim.SetTrigger("triggerHado");
            _hado = true;
            _attacking = true;
        }
    }

    public void pressP(int tenKey)
    {
        if (!_attacking && (tenKey == 1 || tenKey == 2 || tenKey == 3) && _pdata.IsGround)
        {
            Debug.Log("2P");
            _anim.SetTrigger("trigger2P");
            _2P = true;
            _attacking = true;
        }
        else if (!_attacking && _pdata.IsGround)
        {
            Debug.Log("5P");
            _anim.SetTrigger("trigger5P");
            _5P = true;
            _attacking = true;
        }
    }
    public void pressK(int tenKey)
    {
        if(!_attacking && (tenKey == 1 || tenKey == 2 || tenKey == 3) && _pdata.IsGround)
        {
            Debug.Log("2K");
            _anim.SetTrigger("trigger2K");
            _2K = true;
            _attacking = true;
        }
        else if(!_attacking && _pdata.IsGround)
        {
            Debug.Log("5K");
            _anim.SetTrigger("trigger5K");
            _5K = true;
            _attacking = true;
        }
    }

    public void PandK()
    {
        Debug.Log("ìäÇ∞");
        if (_nageKanou && _pdata.IsGround)
            _anim.SetTrigger("triggerThrow");
        _syoryu = false;
        _hado = false;
        _5K = false;
        _2K = false;
        _5P = false;
        _2P = false;
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
        _syoryu = false;
        _hado = false;
        _attacking = false;
        _5K = false;
        _2K = false;
        _5P = false;
        _2P = false;
        _nageKanou = true;
    }

    public void nageKyan()
    {
        _nageKanou = false;
    }
}
