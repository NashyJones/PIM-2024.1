using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoodEnding : MonoBehaviour, IInteractable
{
    public bool IsGoodEnding;

    public void Interact(PointClickInteraction pointClick)

    {
        if (IsGoodEnding)
        {
            SceneManager.LoadScene("GoodEnding");

        }

        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public AnimationCurve hasCurve()
    {
        return null;
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
