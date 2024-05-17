using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour

{
    public GameObject[] tutorial;
    private int state = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < tutorial.Length; i++)
        {
            tutorial[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            tutorial[state].SetActive(false);
            state++;
            if (state >= tutorial.Length)
            {
                SceneManager.LoadScene("CutsceneA");
            }
            else
            {
                tutorial[state].SetActive(true);

            }
        }


    }
}
