using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//colocar interface de interact
public class Pickable : MonoBehaviour, IInteractable
{
    public void Interact(PointClickInteraction pointClick)
    {
       //colocar isso em todo objeto de pegar pras quests
        for (int i = 0; i < pointClick.taskObjects.Count; i++) { 
            
            if (pointClick.taskObjects[i] == gameObject)
            {
                pointClick.taskCompletion[i] = true;
                pointClick.refreshText();
            }
        }
        //esse muda conforme o script
        gameObject.SetActive(false);

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
