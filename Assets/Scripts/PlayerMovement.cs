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
    [SerializeField] float dashLength, dashRecoveryLength, spriteGhostAmount;
    [SerializeField] GameObject ghost;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (LevelTimer.levelRunning)
        {
            if (!lockedMovement)
            {
                var moveX = Input.GetAxisRaw("Horizontal");
                var moveY = Input.GetAxisRaw("Vertical");
                direction = new Vector2(moveX, moveY);
                rb.velocity = direction.normalized * speed;
            }

            if(Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(Dash());
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    IEnumerator Dash()
    {
        lockedMovement = true;
        rb.velocity = direction.normalized * (speed * speedMultiplier);
        for(int i = 0; i <spriteGhostAmount; i++)
        {
            yield return new WaitForSeconds(dashLength/spriteGhostAmount);
            Instantiate(ghost, transform.position, Quaternion.identity);
        }
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(dashRecoveryLength);
        lockedMovement = false;
    }
}
