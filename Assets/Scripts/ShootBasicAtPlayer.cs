using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBasicAtPlayer : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletCooldown, bulletSpeed;
    float bulletCooldownTime;

    Transform target;

    private void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        var direction = target.position - transform.position;
        bulletCooldownTime -= Time.deltaTime;
        if(bulletCooldownTime < 0)
        {
            bulletCooldownTime = bulletCooldown;
            var newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody2D>().velocity = direction.normalized * bulletSpeed;
                
        }
    }


}
