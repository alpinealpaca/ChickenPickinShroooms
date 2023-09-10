using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShroomCollector : MonoBehaviour
{
    private int shroomCount = 0;
    public int maxShrooms = 3;

    //script references
    private GrowBehaviour growScript;

    public Image[] magicShrooms; //array
    public Sprite ShroomFill;
    public Sprite noShroom;

    private void Start()
    {
        growScript = GetComponent<GrowBehaviour>();
    }

    void Update()
    {

        UpdateShroomCount();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("MagicShroom"))
        {

            if (shroomCount >= maxShrooms)
            {
                growScript.Grow();
                
            }

            shroomCount++;

            Debug.Log("Shrooms: " + shroomCount);

            Destroy(other.gameObject);
        }

        if (other.CompareTag("ShrinkingShroom"))
        {
            shroomCount = 0;
            growScript.Shrink();

            Destroy(other.gameObject);
        }

    }

    void UpdateShroomCount()
    {
        for (int i = 0; i < magicShrooms.Length; i++)  //for every item/heart in this array, we'll loop through this code 4 times.
        {
            if (i < shroomCount)
            {
                magicShrooms[i].sprite = ShroomFill;
            }
            else
            {
                magicShrooms[i].sprite = noShroom;
            }

            if (i < maxShrooms)
            {
                magicShrooms[i].enabled = true;
            }
            else
            {
                magicShrooms[i].enabled = false;
            }
            
            if (shroomCount == 3)
            {
                StartCoroutine(ResetShrooms());
            }
        }     
    }

    IEnumerator ResetShrooms()
    {
        yield return new WaitForSeconds(1.0f);

        for (int i = 0; i < magicShrooms.Length; i++)
        {
            magicShrooms[i].sprite = noShroom;
        }

        shroomCount = 0;
    }







}
