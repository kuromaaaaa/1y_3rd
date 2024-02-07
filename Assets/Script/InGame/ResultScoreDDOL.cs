using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScoreDDOL : MonoBehaviour
{
    [SerializeField] int _p1HP;
    public int P1HP { get { return _p1HP; } set { _p1HP = value; } }
    [SerializeField] int _p2HP;
    public int P2HP { get { return _p2HP; } set {  _p2HP = value; } }

    Text _winText;
    bool _started = false;
    // Start is called before the first frame update
    void Start()
    {
        if(FindObjectsOfType<ResultScoreDDOL>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            sceneChange();
            _started = true;
        }
    }

    void OnLevelWasLoaded(int level)
    {
        if (_started) sceneChange();
    }

    void sceneChange()
    {
        if (GameObject.Find("WinPlayer"))
        {
            _winText = GameObject.Find("WinPlayer").GetComponent<Text>();
        }
        GameObject unityChan = GameObject.Find("WinUnitychan");
        if (unityChan != null)
        {
            Time.timeScale = 1.0f;
            Invoke("CamMove", 0.1f);
            if (_p1HP > _p2HP)
            {
                unityChan.GetComponent<Outline>().OutlineColor = new Color(0f, 1f, 0.55f, 1f);
                _winText.text = "PLAYER 1\r\nWIN";
                _winText.color = new Color(0f, 1f, 0.55f, 1f);
            }
            else
            {
                unityChan.GetComponent<Outline>().OutlineColor = new Color(1f, 1f, 0f, 1f);
                _winText.text = "PLAYER 2\r\nWIN";
                _winText.color = new Color(1f, 1f, 0f, 1f);
            }
        }
    }

    void CamMove()
    {
        GameObject.Find("CM vcamEnd").GetComponent<CinemachineVirtualCamera>().Priority = 11;
    }
}
