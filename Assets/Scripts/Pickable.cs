using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//colocar interface de interact
public class Pickable : MonoBehaviour, IInteractable
{
    public string Key;
    public string Lock;
    public bool ShouldDisappear;
    public AnimationCurve Curve;
    public float Tempo;
    [HideInInspector]
    public float TempoRestante;
    private Coroutine Timer;
    public AudioSource sfx;

    public AudioSource somContinuo;

    public Renderer meshRenderer;

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

        
        pointClick.isMiniGame = true;
        pointClick.Canvas.startMinigame(hasCurve());
        pointClick.GetComponent<FirstPersonController>().enabled = false;
        

        pointClick.taskCompleted += CompleteTask;
        Timer = StartCoroutine(TimerCoroutine(pointClick));

        

    }

    private IEnumerator TimerCoroutine(PointClickInteraction pointClick)
    {
        TempoRestante = Tempo;
        pointClick.Canvas.RefreshTimerText(TimeSpan.FromSeconds(TempoRestante).ToString().Substring(3));
        while (true)
        {
           yield return new WaitForSeconds(1);
            TempoRestante -= 1;
            pointClick.Canvas.RefreshTimerText(TimeSpan.FromSeconds(TempoRestante).ToString().Substring(3));
            if (TempoRestante <= 0)
            {
                SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
                break;


            }
        }
        
    }
   

    public void CompleteTask(PointClickInteraction pointClick) 
    {
        pointClick.taskCompleted -= CompleteTask;
        StopCoroutine(Timer);




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
            meshRenderer.enabled = false;
        }
        
        sfx.Play();
        

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public AnimationCurve hasCurve()
    {
        return Curve;

    }
}
