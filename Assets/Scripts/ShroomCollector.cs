using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShroomCollector : MonoBehaviour
{
    private int shroomCount = 0;

    //script references
    private GrowBehaviour growScript;
    //growScript = GetComponent<GrowBehaviour>();


    private void Start()
    {
        growScript = GetComponent<GrowBehaviour>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        
        Debug.Log("collided");
        
        if (other.CompareTag("MagicShroom"))
        {
            shroomCount++;

            if (shroomCount >= 5)
            {
                //other.GetComponent<GrowBehaviour>().Grow();
                growScript.Grow();
            }

            Debug.Log("Shrooms: " + shroomCount);

            Destroy(other.gameObject);
        }

        if (other.CompareTag("ShrinkingShroom"))
        {
            
            growScript.Shrink();

            Destroy(other.gameObject);
        }

    }



}
