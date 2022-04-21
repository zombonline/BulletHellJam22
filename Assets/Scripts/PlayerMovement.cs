using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    bool lockedMovement = false;
    Rigidbody2D rb;
    Vector2 direction;

    [Header("Dash")]
    [SerializeField] float speedMultiplier;
    [SerializeField] float dashLength, dashRecoveryLength, spriteGhostAmount, dashCooldown;
    float dashCooldownTime;
    [SerializeField] GameObject ghost;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        dashCooldownTime = dashCooldown;
    }
    private void Update()
    {
        if (LevelTimer.levelRunning)
        {
            Move();
            CheckForDash();
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

        dashCooldownTime -= Time.deltaTime;

    }

    private void CheckForDash()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (direction != Vector2.zero && dashCooldownTime <0)
            {
                dashCooldown = dashCooldownTime;
                StartCoroutine(Dash());
            }
        }
    }

    private void Move()
    {
        if (!lockedMovement)
        {
            var moveX = Input.GetAxisRaw("Horizontal");
            var moveY = Input.GetAxisRaw("Vertical");
            direction = new Vector2(moveX, moveY);
            rb.velocity = direction.normalized * speed;
        }
    }

    IEnumerator Dash()
    {
        lockedMovement = true;
        GetComponent<Health>().canHit = false;
        rb.velocity = direction.normalized * (speed * speedMultiplier);
        for(int i = 0; i <spriteGhostAmount; i++)
        {
            yield return new WaitForSeconds(dashLength/spriteGhostAmount);
            Instantiate(ghost, transform.position, Quaternion.identity);
        }
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(dashRecoveryLength);
        GetComponent<Health>().canHit = true;
        lockedMovement = false;
    }
}
