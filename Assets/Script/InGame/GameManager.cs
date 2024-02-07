using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    GameObject _player1;
    GameObject _player2;
    [SerializeField] Text _timeTx;
    [SerializeField] Text _winner;
    GameObject[] _playerArr;
    [SerializeField] float _time = 5;
    public GameObject[] PlayerArr { get { return _playerArr; } }
    CenterPlayers _camPlayerCenter;
    GameObject[] _particleArr;

    bool _gameOver = false;
    public bool GameOver { get { return _gameOver; } }
    [SerializeField] string _resultSceneName;

    [SerializeField] Transform _rightWallThrowPosi;
    [SerializeField] Transform _leftWallThrowPosi;
    [SerializeField] GameObject _timeUpTextPrefub;
    [SerializeField] GameObject _readyPrefub;
    [SerializeField] float _readyInsTime = 1;
    [SerializeField] GameObject _fightPrefub;
    [SerializeField] float _fightInsTime = 2;
    [SerializeField] UnityEvent _pause;
    [SerializeField] UnityEvent _resume;
    bool _paused = false;
    void Ready()
    {
        Instantiate(_readyPrefub).transform.parent = GameObject.Find("Canvas").transform;
    }

    void Fight()
    {
        Instantiate(_fightPrefub).transform.parent = GameObject.Find("Canvas").transform;
        _gameOver = false;
    }

    void Awake()
    {
        Invoke("Ready", _readyInsTime);
        Invoke("Fight", _fightInsTime);
        _gameOver = true;
        _playerArr = GameObject.FindGameObjectsWithTag("Player");
        _particleArr = GameObject.FindGameObjectsWithTag("PlayerParticle");
        PlayerData pdp1;
        PlayerData pdp2;
        PlayerParticles parArr1 = _particleArr[0].GetComponent<PlayerParticles>();
        PlayerParticles parArr2 = _particleArr[1].GetComponent<PlayerParticles>();
        if (_playerArr[0].transform.position.x < _playerArr[1].transform.position.x)
        {
            _playerArr[0].tag = "Player1";
            _playerArr[1].tag = "Player2";
            pdp1 = _playerArr[0].GetComponent<PlayerData>();
            pdp2 = _playerArr[1].GetComponent<PlayerData>();
            pdp1.Player1 = true;
            pdp2.Player1 = false;
            _player1 = _playerArr[0];
            _player2 = _playerArr[1];
            pdp1.PP = parArr1;
            pdp2.PP = parArr2;
            parArr1.Parent = _playerArr[0];
            parArr2.Parent = _playerArr[1];
        }
        else
        {
            _playerArr[1].tag = "Player1";
            _playerArr[0].tag = "Player2";
            pdp1 = _playerArr[1].GetComponent<PlayerData>();
            pdp2 = _playerArr[0].GetComponent<PlayerData>();
            pdp1.Player1 = true;
            pdp2.Player1 = false;
            _player1 = _playerArr[1];
            _player2 = _playerArr[0];
            pdp1.PP = parArr1;
            pdp2.PP = parArr2;
            parArr1.Parent = _playerArr[1];
            parArr2.Parent = _playerArr[0];
        }
        _playerArr[0].GetComponent<PlayerData>().Enemy = _playerArr[1];
        _playerArr[1].GetComponent<PlayerData>().Enemy = _playerArr[0];
        _camPlayerCenter = GameObject.Find("PlayersCenter").GetComponent<CenterPlayers>();
        _player1.GetComponent<Outline>().OutlineColor = new Color(0f, 1f, 0.55f, 1f);
        _player2.GetComponent<Outline>().OutlineColor = new Color(1f, 1f, 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(!_paused && (Input.GetButtonDown("c1_menu") || Input.GetButtonDown("c2_menu")))
        {
            _pause.Invoke();
        }
        else if(_paused && (Input.GetButtonDown("c1_menu") || Input.GetButtonDown("c2_menu")))
        {
            _resume.Invoke();
        }
        if(!_gameOver)
            _time -= Time.deltaTime;
        int intTime = (int)_time;
        if (intTime == 0 && !_gameOver)
        {
            _gameOver = true;
            Instantiate(_timeUpTextPrefub).transform.parent = GameObject.Find("Canvas").transform;
            _player1.layer = 6;
            _player2.layer = 6;
            Invoke("ResultLoadScene", 4f);
        }
        _timeTx.text = (intTime.ToString());
    }

    public void GMthrow(Vector3 direc ,bool hit ,Vector3 pos)
    {
        direc *= -1;
        Vector3 playertoWallPos;
        if(hit && _rightWallThrowPosi.position.x < pos.x && direc.x > 0)
        {
            playertoWallPos = new Vector3(_rightWallThrowPosi.position.x - pos.x, 0, 0);
            foreach (GameObject player in PlayerArr)
            {
                player.GetComponent<PlayerMove>().ThrowWallMove(playertoWallPos);
            }
        }
        else if(hit && _leftWallThrowPosi.position.x > pos.x && direc.x < 0)
        {
            playertoWallPos = new Vector3(_leftWallThrowPosi.position.x - pos.x, 0, 0);
            foreach (GameObject player in PlayerArr)
            {
                player.GetComponent<PlayerMove>().ThrowWallMove(playertoWallPos);
            }
        }
        else 
        {
            playertoWallPos = Vector3.zero;
        }
        _camPlayerCenter.throwCam(direc, playertoWallPos, hit);
    }

    public void lose(string player)
    {
        if (player == "Player1")
            _winner.text = "2P PLAYER WIN";
        else _winner.text = "1P PLAYER WIN";
        GameObject.Find("BGM").GetComponent<AudioSource>().Stop();
        _gameOver = true;
        Invoke("ResultLoadScene", 2f);
    }

    public void gameStop()
    {
        _gameOver = true;
    }

    public void gameReStart() 
    {
        _gameOver = false;
    }

    private void ResultLoadScene()
    {
        SceneManager.LoadScene(_resultSceneName);
    }
}
