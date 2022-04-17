using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletSpeed;
    [SerializeField] float bulletCooldownAmount = 1.5f;
    float bulletCooldownTime;

    private void Update()
    {
        spawnPoint.LookAt(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        bulletCooldownTime -= Time.deltaTime;
        if(Input.GetMouseButton(0) && bulletCooldownTime < 0)
        {
            bulletCooldownTime = bulletCooldownAmount;
            var direction = Vector2.Angle((Vector2)transform.forward, (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition));
            var newBullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
