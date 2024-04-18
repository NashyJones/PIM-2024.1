using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ClearedLevelScreen : MonoBehaviour, IInteractable
{
    public string LevelName;


    public void Interact(PointClickInteraction pointClick)
    {
        bool Complete = true;
        for (int i=0; i<pointClick.taskCompletion.Count; i++)
        {
           if (!pointClick.taskCompletion[i])
            {
                Complete = false;

                break;

            }
        }
        if (Complete) 
        { 
            SceneManager.LoadScene(LevelName);

        }
       
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
