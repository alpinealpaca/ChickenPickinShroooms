using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayer1 : MonoBehaviour
{
    private Rigidbody2D rBody;
    private Animator anim;
    private CapsuleCollider2D capsColl2D; //
    

    //movement speed
    [SerializeField] private float moveSpeed;
    private float moveX = 0f;
    private float moveY = 0f;


    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        ///anim = GetComponent<Animator>();
        capsColl2D = GetComponent<CapsuleCollider2D>(); 

        anim = GetComponent<Animator>();
    }

    
    void Update() 
    {

        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveY = 1f;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            moveY = -1f;
        }
        else 
        {
            moveY = 0f;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveX = 1f;
            // Flip character direction
            //transform.localScale = new Vector3(-1, 1, 1);

            if (anim != null)
            {
                anim.SetBool("K_WalkRight", true); 
                anim.SetBool("K_WalkLeft", false);
            }  
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveX = -1f;
            // Flip character direction
            //transform.localScale = new Vector3(1, 1, 1);
            if (anim != null)
            {
                anim.SetBool("K_WalkLeft", true);
            anim.SetBool("K_WalkRight", false); 
            }  

        }
        else 
        {
            moveX = 0f;

            if (anim != null)
            {
            //anim.SetBool("K_Idle_Left");
            anim.SetBool("K_WalkLeft", false); // Set K_WalkLeft to false when not moving
            anim.SetBool("K_WalkRight", false); 
            }  
            
        }

             

    }

    private void FixedUpdate() 
    { 
        //movement calculations
        //horizontal movement
        rBody.velocity = new Vector2(moveX * moveSpeed, rBody.velocity.y);
        //Vertical movement
        rBody.velocity = new Vector2(rBody.velocity.x, moveY * moveSpeed);

    }
}
