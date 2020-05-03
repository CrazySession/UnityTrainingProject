using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwo : MonoBehaviour
{

    Rigidbody2D rgb2D;
    Animator animator;
    Vector2 position,scale;
    public ParticleSystem speedEffect;
    /* Scale Vector is used to change localScale for animation purpose */ 

    public float SPEED = 6.0f;
    public int maxHealth = 5;
    float invincibleTime = 0.0f;

    bool idle = true;
    int currentHealth;
    public float invincibleTimer = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        rgb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        scale = transform.localScale;
        position = rgb2D.position;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(invincibleTime > 0.01f)
        {
            invincibleTime -= Time.deltaTime;
        }

        //Resets Input to Zero every frame so character won´t move infinite when no more button is pressed
        float moveX = 0.0f;
        float moveY = 0.0f;


        //fixing bug where player "teleports" after getting unstuck from object ---- mostly works
        if((rgb2D.position.x - position.x) > 0.5 || (rgb2D.position.x - position.x) < -0.5)
        {
            position = rgb2D.position;
        }

        if ((rgb2D.position.y - position.y) > 0.5 || (rgb2D.position.y - position.y) < -0.5)
        {
            position = rgb2D.position;
        }


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

        if (Input.GetKey(KeyCode.W))
        {
            moveY = 1.0f;
            scale.x = +1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveY = -1.0f;
            scale.x = -1;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            SPEED = 9.0f;
            speedEffect.Play();
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            SPEED = 6.0f;
            speedEffect.Stop();
        }

        Debug.Log(SPEED);

        //checks if moveX is == 0.0f - Approximately used because float numbers rarely are true 0 once initiated
        //bool variable/function needed to set animation from walking back to idle
        if (!(Mathf.Approximately(moveX, 0.0f)) || !(Mathf.Approximately(moveY, 0.0f)))
        {
            idle = false;
        }
        else
        {
            idle = true;
            animator.SetFloat("Speed", 0.0f);
        }

        //creates a new Vector2 var to store the PlayerInput moveDirection
        //normalized to set the Vector always to 1. Avoids faster movement while moving diagonal. (e.g. pressing W + D)
        Vector2 moveDir = new Vector2(moveX, moveY).normalized;

        //set the animator Parameters to handle correct animation
        if(moveX > 0.5 || moveX < -0.5)
        {
            animator.SetFloat("Speed", moveX);
        }

        if(moveY > 0.5 || moveY < -0.5)
        {
            animator.SetFloat("Speed", moveY);
        }

        animator.SetBool("Idle", idle);

        //Player Movement
        position = position + (moveDir * SPEED * Time.deltaTime);

        //transfers changed variables to components so they can be updated
        rgb2D.MovePosition(position);
        transform.localScale = scale;

        //Debug.Log($"{idle}/{moveX}/{moveY}");

    }

    public void changeHealth(int amount)
    {
        if(invincibleTime > 0.01f)
        {
            Debug.Log("cant get hit");
            return;
        }

        if (amount < 0)
        {
            Debug.Log("Hit");
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);

        if(currentHealth == 0)
        {
            Debug.Log("You died!");
            Destroy(gameObject);
            return;
        }

        invincibleTime = invincibleTimer;
    }
}
