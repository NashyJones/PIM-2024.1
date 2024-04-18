using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour, IInteractable

{
    public string animationOpen;
    public string animationClose;
    public float closeTime;
    public int RequiredTasks = -1;


    public void Interact(PointClickInteraction pointClick)
    {
        if (RequiredTasks != -1)
        {
            
            for (int i = 0; i < RequiredTasks; i++)
            {
                if (!pointClick.taskCompletion[i])
                {
                    return;
                }
            }
        }
        GetComponent<Animation>().Play(animationOpen);
        GetComponentInChildren<Collider>().enabled = false;
        Invoke("closeDoor", closeTime);

    }
    public void closeDoor()

    {
        GetComponent<Animation>().Play(animationClose);
        GetComponentInChildren<Collider>().enabled = true;
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
