using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    [SerializeField] float _fadeTime;
    [SerializeField] bool _fadeIn;
    float _timeCount = 0;
    bool _isFade = false;
    string _sceneName;
    Image _image;
    private void Start()
    {
        _image = GetComponent<Image>();
        if(_fadeIn)
        {
            Color c = _image.color;
            c.a = 1;
            _image.color = c;
            _timeCount = _fadeTime;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(_fadeIn)
        {
            _timeCount -= Time.deltaTime;
            Color c = _image.color;
            c.a = _timeCount / _fadeTime;
            _image.color = c;
            if(_timeCount < 0)
            {
                _fadeIn = false;
            }
        }
        if(_isFade)
        {
            _timeCount += Time.deltaTime;
            Color c = _image.color;
            c.a = _timeCount / _fadeTime;
            _image.color = c;
            if (_timeCount > _fadeTime)
            {
                SceneManager.LoadScene(_sceneName);
            }
        }
    }

    public void LoadSceneMethod(string Name)
    {
        if (!_isFade && !_fadeIn)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(Name);
        }
    }

    public void LoadSceneMethodFade(string Name)
    {
        if (!_isFade && !_fadeIn)
        {
            Time.timeScale = 1;
            _isFade = true;
            _sceneName = Name;
        }
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;   // UnityEditorÇÃé¿çsÇí‚é~Ç∑ÇÈèàóù
#else
        Application.Quit();                                // ÉQÅ[ÉÄÇèIóπÇ∑ÇÈèàóù
#endif
    }
}
