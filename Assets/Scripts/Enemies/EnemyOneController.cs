using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOneController : MonoBehaviour
{
    /*### No Transition back to Idle animation included just the arrow back ---> not included yet --- not necessary til now ###*/
    Vector2 startPosition,enemyPosition,scale;

    public bool vertical;
    public float SPEED = 3.0f;
    public bool checkMarkReached = true;

    float compareValue;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        enemyPosition = transform.position;
        scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (vertical)
        {
            compareValue = startPosition.y + enemyPosition.y;
        }
        else
        {
            compareValue = startPosition.x + enemyPosition.x;
        }

        if (compareValue > 2)
        {
            checkMarkReached = false;
            scale.x = 1;
        }

        if (compareValue < -2)
        {
            checkMarkReached = true;
            scale.x = -1;
        }

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

        transform.position = enemyPosition;
        transform.localScale = scale;
    }
}
