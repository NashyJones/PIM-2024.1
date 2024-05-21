using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CanvasTextScript : MonoBehaviour

{
    public PointClickInteraction pointClick;
    public TMPro.TextMeshProUGUI textMeshPro;
    public GameObject Minigamepannel;
    public RectTransform Arrow;
    public GameObject Bar;
    private AnimationCurve CurrentCurve;
    private Coroutine coroutine;
    public TMPro.TextMeshProUGUI TimerText;
    public GameObject pauseCanvas;
    public GameObject ButtonMenu;
    public GameObject HowToPlay;
    public GameObject[] instructions;
    private int howtoplayindex;
    public GameObject HUD;

    public AudioSource finishTimer;
   


    public void RefreshTimerText(string text)
    {
        TimerText.text = text;
    }


    
        
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
        finishTimer.Play();
        Minigamepannel.SetActive(false);
        StopCoroutine(coroutine);
    }

    public void quitgame()
    {
        //Application.Quit(); <- saporra serve pa sair do jogo :D
        SceneManager.LoadScene("MainMenu");

    }

    public void pausegame ()
    {
        pauseCanvas.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        pointClick.pause(true);
        HUD.SetActive(false);
       



    }
    public void resumegame ()
    {
        pauseCanvas.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        pointClick.pause(false);
        HUD.SetActive(true);
    }

    public void howtoplay ()
    {
        howtoplayindex = 0;
        ButtonMenu.SetActive(false);
        HowToPlay.SetActive(true);
        showInstructions();


        
    }
    public void showInstructions ()
    {
        if (howtoplayindex < instructions.Length)
        {
            instructions[Mathf.Clamp(howtoplayindex - 1, 0, instructions.Length-1)].SetActive(false);
            instructions[howtoplayindex].SetActive(true);

        }
        else
        {
            for (int i = 0; i < instructions.Length; i++)
            {
                instructions[i].SetActive(false);
            }
           ButtonMenu.SetActive(true);
            HowToPlay.SetActive(false);
            howtoplayindex = -1;

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        refreshText();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (howtoplayindex>=0)
            {
                howtoplayindex++;
                showInstructions();

            }
            
        }
        else if (Input.GetKeyDown(KeyCode.Escape)) 
        {

            if (!pauseCanvas.activeSelf)
            {
                pausegame();

            }
            else
            {
                resumegame();
            }
        }

       
    }
    

   
}
