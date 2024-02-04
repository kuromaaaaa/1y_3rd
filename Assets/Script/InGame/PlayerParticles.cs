using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticles : MonoBehaviour
{
    [SerializeField] GameObject _parent;
    public GameObject Parent { set { _parent = value; } }
    [SerializeField] List<ParticleSystem> _particleList = new List<ParticleSystem>();
    [SerializeField] List<GameObject> _asPrefubList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = _parent.transform.position;
        this.gameObject.transform.rotation = _parent.transform.rotation;
    }
    public void ParticlePlay(int particleNum, int AudioNum)
    {
        _particleList[particleNum].Play();
        Instantiate(_asPrefubList[AudioNum]).transform.position = _particleList[particleNum].transform.position;
    }
    public void ParticlePlay(int particleNum)
    {
        _particleList[particleNum].Play();
    }
}
