using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwo : MonoBehaviour
{

    Rigidbody2D rgb2D;
    Animator animator;
    Vector2 position,scale;
    /* Scale Vector is used to change localScale for animation purpose */ 

    public float SPEED = 6.0f;
    bool idle = true;

    // Start is called before the first frame update
    void Start()
    {
        rgb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        position = rgb2D.position;
        scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        //Resets Input to Zero every frame so character won´t move infinite when no more button is pressed
        float moveX = 0.0f;
        
        //Player Input
        if (Input.GetKey(KeyCode.D))
        {
            moveX = +1.0f;
            scale.x = +1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1.0f;
            scale.x = -1;
        }

        //checks if moveX is == 0.0f - Approximately used because float numbers rarely are true 0 once initiated
        //bool variable/function needed to set animation from walking back to idle
        if(!(Mathf.Approximately(moveX, 0.0f)))
        {
            idle = false;
        }
        else
        {
            idle = true;
        }

        //creates a new Vector2 var to store the PlayerInput moveDirection
        //normalized to set the Vector always to 1. Avoids faster movement while moving diagonal. (e.g. pressing W + D)
        Vector2 moveDir = new Vector2(moveX, 0).normalized;

        //set the animator Parameters to handle correct animation
        animator.SetFloat("Speed", moveX);
        animator.SetBool("Idle", idle);

        //Player Movement
        position = position + (moveDir * SPEED * Time.deltaTime);

        //transfers changed variables to components so they can be updated
        rgb2D.MovePosition(position);
        transform.localScale = scale;
    }
}
