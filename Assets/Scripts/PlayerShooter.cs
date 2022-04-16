using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletCooldownAmount = 1.5f;
    float bulletCooldownTime;

    private void Update()
    {

        bulletCooldownAmount -= Time.deltaTime;
        if(Input.GetMouseButton(0))
        {
            bulletCooldownAmount = bulletCooldownTime;
            var newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
    }
}
