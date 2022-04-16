using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    bool lockedMovement = false;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        var moveX = Input.GetAxisRaw("Horizontal");
        var moveY = Input.GetAxisRaw("Vertical");
        Vector2 direction = new Vector2(moveX, moveY);

        if(!lockedMovement)
        {
            rb.velocity = direction.normalized * speed;
        }
    }


}
