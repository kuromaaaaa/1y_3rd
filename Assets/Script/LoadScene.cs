using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    [SerializeField] float _fadeTime;
    float _timeCount = 0;
    bool _isFade = false;
    string _sceneName;
    Image _image;
    private void Start()
    {
        _image = GetComponent<Image>();
    }
    // Update is called once per frame
    void Update()
    {
        if(_isFade)
        {
            _timeCount += Time.deltaTime;
            Color c = _image.color;
            c.a = _timeCount / _fadeTime;
            _image.color = c;
        }
        if(_timeCount > _fadeTime)
        {
            SceneManager.LoadScene(_sceneName);
        }
    }

    public void LoadSceneMethod(string Name)
    {
        if (!_isFade)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(Name);
        }
    }

    public void LoadSceneMethodFade(string Name)
    {
        if (!_isFade)
        {
            Time.timeScale = 1;
            _isFade = true;
            _sceneName = Name;
        }
    }
}
