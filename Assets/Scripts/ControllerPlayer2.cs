using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayer2 : MonoBehaviour
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
    }

    
    void Update() 
    {

        if (Input.GetKey(KeyCode.W))
        {
            moveY = 1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveY = -1f;
        }
        else 
        {
            moveY = 0f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveX = 1f;
            // Flip character direction
            transform.localRotation = Quaternion.Euler(0, 0, 0); //transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
            // Flip character direction
            transform.localRotation = Quaternion.Euler(0, 180, 0); //transform.localScale = new Vector3(1, 1, 1);
        }
        else 
        {
            moveX = 0f;
        }
        //animations//
        ///anim.SetBool("Run", moveX != 0);

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
