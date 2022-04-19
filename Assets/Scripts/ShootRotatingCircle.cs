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
            newBullet1.transform.rotation = new Quaternion(newBullet1.transform.rotation.x,
            newBullet1.transform.rotation.y,
            newBullet1.transform.rotation.z + 45, newBullet1.transform.rotation.w);
            
            var newBullet2 = Instantiate(bulletPrefab, transform.position, transform.rotation);
            newBullet2.transform.rotation = new Quaternion(newBullet1.transform.rotation.x,
            newBullet2.transform.rotation.y,
            newBullet2.transform.rotation.z + 90, newBullet2.transform.rotation.w);

            var newBullet3 = Instantiate(bulletPrefab, transform.position, transform.rotation);
            newBullet3.transform.rotation = new Quaternion(newBullet1.transform.rotation.x,
            newBullet3.transform.rotation.y,
            newBullet3.transform.rotation.z + 135, newBullet3.transform.rotation.w);
        }
        }

    }
}
