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
    [SerializeField] GameObject _throwColli;
    [SerializeField] GameObject _AirKcolli;
    [SerializeField, Tooltip("�����U����̋���")] float _throwEndDistance;
    //[SerializeField] float _aaaa;

    PlayerData _pdata;
    PlayerDirection _pdire;
    Rigidbody _rb;
    PlayerMove _pmove;

    bool _syoryu = false;
    bool _syoryuMove = false;
    public bool SyoryuMove { get { return _syoryuMove; } }
    public bool Syoryu { get { return _syoryu; } }
    bool _hado = false;
    bool _attacking = false;
    bool _nageKanou = true;
    public bool Attacking { get { return _attacking; } set { _attacking = value; } }
    bool _cancelCommandAttack = false;
    public bool CancelCommandAttack { get { return _cancelCommandAttack; } }
    Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _pdata = GetComponent<PlayerData>();
        _pdire = GetComponent<PlayerDirection>();
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
        _pmove = GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_syoryuMove)
        {
            _rb.velocity = _pdire.PlayerFo * 2f;
        }
    }

    public void syoryuHassei()
    {
        if ((!_attacking && _pdata.IsGround) || _cancelCommandAttack)
        {
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
        if ((!_attacking && _pdata.IsGround) || _cancelCommandAttack)
        {
            _anim.SetTrigger("triggerHado");
            _hado = true;
            _attacking = true;
        }
    }

    public void pressP(int tenKey)
    {
        if (!_attacking && (tenKey == 1 || tenKey == 2 || tenKey == 3) && _pdata.IsGround && !_pdata.Damaging)
        {
            _anim.SetTrigger("trigger2P");
            _attacking = true;
        }
        else if (!_attacking && _pdata.IsGround && !_pdata.Damaging)
        {
            _anim.SetTrigger("trigger5P");
            _attacking = true;
        }
    }
    public void pressK(int tenKey)
    {
        if(!_attacking && (tenKey == 1 || tenKey == 2 || tenKey == 3) && _pdata.IsGround && !_pdata.Damaging)
        {
            _anim.SetTrigger("trigger2K");
            _attacking = true;
        }
        else if(!_attacking && _pdata.IsGround && !_pdata.Damaging)
        {
            _anim.SetTrigger("trigger5K");
            _attacking = true;
        }
    }

    public void PandK()
    {
        if (_nageKanou && _pdata.IsGround)
        {
            _anim.SetTrigger("triggerThrow");
        }
        _syoryu = false;
        _hado = false;
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

    public void throwColli()
    {
        _throwColli.SetActive(true);
    }

    public void AirK()
    {
        _AirKcolli.SetActive(true);
    }


    public void hado()
    {
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
        _nageKanou = true;
        _syoryuMove = false;
        //_rb.isKinematic = false;
    }

    public void throwEnd(int hit)
    {
        if (hit == 1)
        {
            this.transform.position = this.transform.position + (_pdire.ThrowEndFo * _throwEndDistance);
            GetComponent<PlayerMove>().JEH = false;
            _pdata.Flip = true;
        }
        else
        {
            this.transform.position = this.transform.position + (_pdire.PlayerFo * _throwEndDistance);
        }
    }

    void CanCommandCancel()
    {
        _cancelCommandAttack = true;
    }

    void CantCommandCancel()
    {
        _cancelCommandAttack = false;
    }


    public void NageKyan()
    {
        _nageKanou = false;
    }

    public void NageKanou()
    {
        _nageKanou = true;
    }
}
