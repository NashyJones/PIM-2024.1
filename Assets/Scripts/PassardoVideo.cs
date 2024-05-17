using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;


public class PassardoVideo : MonoBehaviour
{
    public VideoPlayer Cutscene;
    private bool _Lock = true;
    public string proxnivel;
    public VideoPlayer Loop;
    private int state = 0;
    private VideoPlayer CurrentVideo;
    public GameObject CutsceneCanvas;
    public GameObject LoopCanvas;
  



    // Start is called before the first frame update
    void Start()
    {
        CurrentVideo = Cutscene;
        
        
    }

    // Update is called once per frame
    void Update()
    {
       if (CurrentVideo.isPlaying)
        {
            _Lock = false;
            if (state == 2)
            {
                if (Input.anyKeyDown)
                {
                    SceneManager.LoadScene(proxnivel);


                }
                
            }
        }

        if (!CurrentVideo.isPlaying && !_Lock)
        {
           
            switch (state)
                {
                case 0 :
                    _Lock = true;
                    CurrentVideo = Loop;
                    LoopCanvas.SetActive(true);
                    CutsceneCanvas.SetActive(false);
                    CurrentVideo.Play();
                    state = 2;
                    break;
                
               
            }
            

        }
    }
}
