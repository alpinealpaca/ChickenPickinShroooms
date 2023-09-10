using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomLife : MonoBehaviour
{
    [SerializeField] float lifespan = 5f;


    void Update()
    {
        lifespan -= Time.deltaTime;
        if (lifespan <= 0f)
        {
            Destroy(gameObject);
        }
    }

}
