using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomMove : MonoBehaviour
{
    public bool wallTrigger;

    private float latestDirectionChangeTime;
    private readonly float directionChangeTime = 4f;
    private float characterVelocity = 4f;
    private Vector3 movementDirection;
    private Vector3 movementPerSecond;
    private Vector2 center;

    private void Start()
    {
        latestDirectionChangeTime = 0f;
        center = new Vector2(0, 0);

        calcuateNewMovementVector();

    }

    void calcuateNewMovementVector()
    {
        movementDirection = new Vector3(Random.Range(-20.0f, 20.0f), Random.Range(-15.0f, 15.0f),44.4f).normalized;
        movementPerSecond = movementDirection * characterVelocity;
    }

    private void Update()
    {
        if (wallTrigger == true)
        {
                latestDirectionChangeTime = Time.time;
                calcuateNewMovementVector();
        }

        if (Time.time - latestDirectionChangeTime > directionChangeTime)
        {
            latestDirectionChangeTime = Time.time;
            calcuateNewMovementVector();
        }
        RandomMove();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            wallTrigger = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            wallTrigger = false;
        }
    }

    void RandomMove()
    {
        transform.position = new Vector3(transform.position.x + (movementPerSecond.x * Time.deltaTime), transform.position.y + (movementPerSecond.y * Time.deltaTime),44.4f);
    }
}
