using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PointClickInteraction : MonoBehaviour
{
    public LayerMask interactableLayer; // The layer mask for interactable objects

    private Camera mainCamera;

    public List<GameObject> taskObjects = new List<GameObject>();

    public List<string> taskNames = new List<string>();
    
    public List<bool> taskCompletion = new List<bool>();

    public int HiddenTasks = -1;

    public delegate void OnTaskCompleted(PointClickInteraction pointClick);

   public  OnTaskCompleted taskCompleted;

    public bool isMiniGame = false;
    public int tamanhoraycast;



    public CanvasTextScript Canvas;
    [ HideInInspector ]

    public List<string> inventory = new List<string>();
    public void refreshText ()
    {
        Canvas.refreshText ();
    }
    void Start()
    {
        mainCamera = Camera.main;
        taskCompleted += reactivateFPC;

    }

    void Update()
    {
        if (isMiniGame)
        {
           if (Input.GetKeyDown (KeyCode.Space))
            {
                Canvas.hitTarget();
            }
        }
        if (Input.GetMouseButtonDown(0)) // Left mouse button clicked
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, tamanhoraycast, interactableLayer))
            {
                GameObject obj = hit.collider.gameObject;
                // Perform interaction with the object (e.g., show UI, play animation, etc.)
                Debug.Log("Interacted with: " + obj.name);

                if (obj.GetComponent<IInteractable>() != null)
                {
                    obj.GetComponent<IInteractable>().Interact(this);
                   

                  
                    
                }
                       

            }
        }
    }

    public void reactivateFPC(PointClickInteraction pointClick)
    {
        GetComponent<FirstPersonController>().enabled = true;
        isMiniGame = false;

    }

    public void pause (bool _pause)
    {
        GetComponent<FirstPersonController>().enabled = !_pause;
    }
}
