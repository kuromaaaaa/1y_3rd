using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticles : MonoBehaviour
{
    [SerializeField]GameObject _parent;
    public GameObject Parent { set { _parent = value; } }
    [SerializeField]List<ParticleSystem> _particleList = new List<ParticleSystem>();
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
    public void ParticlePlay(int num)
    {
        _particleList[num].Play();
    }
}
