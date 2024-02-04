using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camPriority : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CinemachineVirtualCamera>().Priority = 11;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
