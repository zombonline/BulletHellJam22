using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRotatingCircle : MonoBehaviour
{
     [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletCooldown, bulletSpeed, rotateSpeed;
    float bulletCooldownTime;

    void Update()
    {
        transform.Rotate (0,0,rotateSpeed*Time.deltaTime);

        if(LevelTimer.levelRunning)
        {
        bulletCooldownTime -= Time.deltaTime;
        if(bulletCooldownTime < 0)
        {
            bulletCooldownTime = bulletCooldown;
            var newBullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            var newBullet1 = Instantiate(bulletPrefab, transform.position, transform.rotation);
            newBullet1.transform.Rotate(new Vector3(0,0,90));
            
            var newBullet2 = Instantiate(bulletPrefab, transform.position, transform.rotation);
            newBullet2.transform.Rotate(new Vector3(0,0,180));

            var newBullet3 = Instantiate(bulletPrefab, transform.position, transform.rotation);
            newBullet3.transform.Rotate(new Vector3(0,0,-90));

        }
        }

    }
}
