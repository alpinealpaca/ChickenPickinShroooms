using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowBehaviour : MonoBehaviour
{
    public GameObject WinScreen;

    private Vector3 initialScale;
    public float growthRate = 0.1f;
    public float shrinkRate = 0.1f;

    public int growthScore = 0;

    private void Start()
    {
        initialScale = transform.localScale;
    }

 

    public void Grow()
    {
        Debug.Log("Grow!");
        if (growthScore <=3)
        {
            growthScore += 1;
            Debug.Log(growthScore);
            transform.localScale += new Vector3(growthRate, growthRate, 0f);
        } 
        //Victory
        if (growthScore >= 3)
        {
             Debug.Log("Win");
             WinScreen.gameObject.SetActive(true);

        }
       
    }

    public void Shrink()
    {
        if (growthScore >= 1)
        {
            growthScore -= 1;
            Debug.Log(growthScore);
            transform.localScale -= new Vector3(shrinkRate, shrinkRate, 0f);
        }
       
    }


}
