using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KnifeReload : MonoBehaviour, IInteractable
{
    public bool IsGameOver;

    public void Interact(PointClickInteraction pointClick)
    
    {
       if (IsGameOver)
        {
            SceneManager.LoadScene("GameOver");

        }
        
       else
        {
            SceneManager.LoadScene (SceneManager.GetActiveScene().name);
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
