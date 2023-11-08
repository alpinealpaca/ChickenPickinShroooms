using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public static Music instance; 

    private void Awake()  // If there is already a MusicScript instance, make it active. Otherwsie don't.
    {
        DontDestroyOnLoad(this.gameObject); 

        if (instance == null) 
        {
            instance = this; 
        }
        else 
        {
            Destroy(gameObject); 
        }
    }

    //GetComponent<AudioSource>().volume = 0.5f;
}
