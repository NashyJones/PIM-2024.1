using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    public Doors door;
    public AudioSource sfx;

    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            if (other.GetComponent<PointClickInteraction>() != null)
            {
                PointClickInteraction pointClick = other.GetComponent<PointClickInteraction>();

                for (int i = 0; i < pointClick.taskObjects.Count; i++)
                {

                    if (pointClick.taskObjects[i] == gameObject)
                    {
                        pointClick.taskCompletion[i] = true;
                        pointClick.refreshText();
                        if (door != null)
                        {
                            if (!door.GetComponentInChildren<Collider>().enabled) 
                            door.closeDoor();

                        }
                    }
                }
            }
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
