using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletSpeed;
    [SerializeField] float bulletCooldownAmount = 1.5f;
    float bulletCooldownTime;

    private void Update()
    {
        bulletCooldownTime -= Time.deltaTime;
        if(Input.GetMouseButton(0) && bulletCooldownTime < 0)
        {
            bulletCooldownTime = bulletCooldownAmount;
            var direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
            var atan2 = Mathf.Atan2(direction.y, direction.x);
            var newBullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            newBullet.transform.rotation = Quaternion.Euler(0f, 0f, atan2 * Mathf.Rad2Deg);
        }
    }
}
