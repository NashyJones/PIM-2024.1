using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasTextScript : MonoBehaviour

{
    public PointClickInteraction pointClick;
    public TMPro.TextMeshProUGUI textMeshPro;

        
    public void refreshText ()
    {
        textMeshPro.text = string.Empty;

        for (int i = 0; i<pointClick.taskNames.Count; i++)
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
