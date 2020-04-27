using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOneController : MonoBehaviour
{

    Vector2 startPosition,enemyPosition;

    public bool vertical;
    public float SPEED = 3.0f;
    public bool checkMarkReached = true;

    float compareValue;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        enemyPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        compareValue = startPosition.x + enemyPosition.x;

        if (compareValue > 2)
        {
            checkMarkReached = false;
        }

        if (compareValue < -2)
        {
            checkMarkReached = true;
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
    }
}
