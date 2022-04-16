using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] bool moveX, moveY;

    [SerializeField] float boundaryX, boundaryY;
    Vector2 targetPos;

    private void Start()
    {
        SetNewTargetPosition();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        if ((Vector2)transform.position == targetPos)
        {
            SetNewTargetPosition();
        }

    }

    private void SetNewTargetPosition()
    {
        if (moveX && moveY)
        {
            var targetX = Random.Range(-boundaryX, boundaryX);
            var targetY = Random.Range(-boundaryY, boundaryY);

            targetPos = new Vector2(targetX, targetY);
        }
        else if (moveX && !moveY)
        {
            var targetX = Random.Range(-boundaryX, boundaryX);
            targetPos = new Vector2(targetX, transform.position.y);
        }
        else if (!moveX && moveY)
        {
            {
                var targetY = Random.Range(-boundaryY, boundaryY);
                targetPos = new Vector2(transform.position.x, targetY);
            }
        }
    }
}
