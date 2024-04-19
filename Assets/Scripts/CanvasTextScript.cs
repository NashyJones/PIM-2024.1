using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasTextScript : MonoBehaviour

{
    public PointClickInteraction pointClick;
    public TMPro.TextMeshProUGUI textMeshPro;
    public GameObject Minigamepannel;
    public RectTransform Arrow;
    public GameObject Bar;
    private AnimationCurve CurrentCurve;
    private Coroutine coroutine;
   





    
        
    public void refreshText ()
    {
        textMeshPro.text = string.Empty;

        for (int i = 0; i<pointClick.taskNames.Count; i++)
        {
            if (ShowHiddenTasks())
            {

                if (i >= pointClick.HiddenTasks)
                {
                    if (pointClick.taskCompletion[i])
                    {

                        textMeshPro.text = textMeshPro.text + "<s>" + pointClick.taskNames[i] + "</s> \n";

                    }
                    else
                    {
                        textMeshPro.text = textMeshPro.text + pointClick.taskNames[i] + "\n";
                    }
                }
            }
            else
            {

                if (pointClick.HiddenTasks >= 0 && i < pointClick.HiddenTasks)
                {
                    if (pointClick.taskCompletion[i])
                    {

                        textMeshPro.text = textMeshPro.text + "<s>" + pointClick.taskNames[i] + "</s> \n";

                    }
                    else
                    {
                        textMeshPro.text = textMeshPro.text + pointClick.taskNames[i] + "\n";
                    }
                }
            }

            
           
        }
    }
    
    public bool ShowHiddenTasks()
    {
        for (int i = 0; i< pointClick.HiddenTasks; i++)
        {
            if (!pointClick.taskCompletion[i])
            {
                return false;

            }

        }
        return true;
    }


    public void startMinigame (AnimationCurve curve)
    {
        CurrentCurve = curve;
        Minigamepannel.SetActive(true);
        coroutine = StartCoroutine(animation());
        


    }

    private IEnumerator animation()
    {
        float time = 0;
        float Maxtime = 0;

        Maxtime = CurrentCurve.keys[CurrentCurve.keys.Length - 1].time;
        bool forwardprogress = true;

        while (true)
        {
            

            if (forwardprogress)
            {
                if (time >= Maxtime)
                {
                    time = Maxtime;
                    forwardprogress = false;
                }
                Arrow.anchoredPosition = new Vector2(Mathf.Lerp(-330, -36, CurrentCurve.Evaluate(time)), -130);
                time += Time.deltaTime;
            }
            
            else
            {
                if (time <= 0)
                {
                    time = 0;
                    forwardprogress = true;
                }
                Arrow.anchoredPosition = new Vector2(Mathf.Lerp(-330, -36, CurrentCurve.Evaluate(time)), -130);
                time -= Time.deltaTime;
            }
            yield return null;
        }
    }

    public void hitTarget ()
    {
        if (Arrow.anchoredPosition.x>=-195 && Arrow.anchoredPosition.x <= -174)
        {
            finishMinigame();
            pointClick.taskCompleted(pointClick);

        }
        else
        {
            StopCoroutine(coroutine);
            coroutine = StartCoroutine(animation());
            print ("fail");



        }
    }
    public void finishMinigame()
    {

        Minigamepannel.SetActive(false);
        StopCoroutine(coroutine);
    }
        


    // Start is called before the first frame update
    void Start()
    {
        refreshText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
