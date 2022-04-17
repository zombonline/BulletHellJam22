using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit!");
        if(collision.GetComponent<Health>())
        {
            if (collision.GetComponent<Health>().canHit)
            {
                collision.GetComponent<Health>().RemoveHealth(damage);
                Destroy(gameObject);
            }
        }
    }
}
