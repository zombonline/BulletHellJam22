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
        bulletCooldownTime -= Time.deltaTime;
        if(bulletCooldownTime < 0)
        {
            bulletCooldownTime = bulletCooldown;
            var direction = (target.position - transform.position);
            var atan2 = Mathf.Atan2(direction.y, direction.x);
            var newBullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            newBullet.transform.rotation = Quaternion.Euler(0f, 0f, atan2 * Mathf.Rad2Deg);
        }
    }


}
