using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class SplashSceneManager : MonoBehaviour
{
    public VideoPlayer SplashVideo;
    private bool _Lock = true;
    public string NextScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SplashVideo.isPlaying)
        {
            _Lock = false;

        }
        if (!SplashVideo.isPlaying && !_Lock)
        {
            _Lock = true;
            SceneManager.LoadScene(NextScene);
        }
    }
}
