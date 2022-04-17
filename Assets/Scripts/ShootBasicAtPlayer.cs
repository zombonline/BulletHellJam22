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
            var direction = Vector2.Angle(transform.position, target.position);   
            bulletCooldownTime = bulletCooldown;
            var newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);      
            newBullet.transform.rotation = new Quaternion(0,0, direction, 0);

        }
    }


}
