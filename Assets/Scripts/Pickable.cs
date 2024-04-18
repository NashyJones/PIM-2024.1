using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//colocar interface de interact
public class Pickable : MonoBehaviour, IInteractable
{
    public string Key;
    public string Lock;
    public bool ShouldDisappear;
    public void Interact(PointClickInteraction pointClick)
    {
        if (Lock != string.Empty)
        {
            bool complete = false;
            for (int i = 0; i < pointClick.inventory.Count; i++)
            {
                if (Lock == pointClick.inventory[i])
                {
                    complete = true;

                    break;

                }
            }
            if (!complete) 
            { 
                return;
            }

        }
       

       //colocar isso em todo objeto de pegar pras quests
        for (int i = 0; i < pointClick.taskObjects.Count; i++) 
        { 
            
            if (pointClick.taskObjects[i] == gameObject)
            {
                pointClick.taskCompletion[i] = true;
                pointClick.refreshText();
            }
        }

        //esse muda conforme o script

        pointClick.inventory.Add(Key);


        if (ShouldDisappear)
        {
            gameObject.SetActive(false);
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
