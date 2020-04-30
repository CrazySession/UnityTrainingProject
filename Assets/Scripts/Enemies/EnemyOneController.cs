using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOneController : MonoBehaviour
{
    /*### No Transition back to Idle animation included just the arrow back ---> not included yet --- not necessary til now ###*/
    Rigidbody2D rgb2d;
    Vector2 startPosition,enemyPosition,scale;

    public bool vertical;
    public float SPEED = 3.0f;
    public bool checkMarkReached = true;

    float compareValue, startCompareValue;

    // Start is called before the first frame update
    void Start()
    {
        rgb2d = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        enemyPosition = transform.position;
        scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        //fixing bug where enemy "teleports" after getting unstuck from object ---- mostly works
        if ((rgb2d.position.x - enemyPosition.x) > 0.5 || (rgb2d.position.y - enemyPosition.y) > 0.5)
        {
            enemyPosition = rgb2d.position;
            checkMarkReached = true;
            scale.x = -1;
        }

        if ((rgb2d.position.x - enemyPosition.x) < -0.5 || (rgb2d.position.y - enemyPosition.y) < -0.5)
        {
            enemyPosition = rgb2d.position;
            checkMarkReached = false;
            scale.x = 1;
        }

        Debug.Log(startPosition.y);
        //set compareValue depending on enemy movement
        if (vertical)
        {
            compareValue = enemyPosition.y;
            startCompareValue = startPosition.y;
        }
        else
        {
            compareValue = enemyPosition.x;
            startCompareValue = startPosition.x;
        }
        //check for reachted waypoints and set bool for movement + scale for animation
        if (compareValue > (startCompareValue + 2))
        {
            checkMarkReached = false;
            scale.x = 1;
        }

        if (compareValue < (startCompareValue - 2))
        {
            checkMarkReached = true;
            scale.x = -1;
        }
        //set movement direction according checkMark true or false
        if (checkMarkReached)
        {
            if (vertical)
            {
                enemyPosition.y = enemyPosition.y + SPEED * Time.deltaTime;
            }
            else
            {
                enemyPosition.x = enemyPosition.x + SPEED * Time.deltaTime;
            }
        }
        else
        {
            if (vertical)
            {
                enemyPosition.y = enemyPosition.y - SPEED * Time.deltaTime;
            }
            else
            {
                enemyPosition.x = enemyPosition.x - SPEED * Time.deltaTime;
            }
        }
        //update gameobject variables
        rgb2d.MovePosition(enemyPosition);
        //transform.position = enemyPosition;
        transform.localScale = scale;
    }
}
