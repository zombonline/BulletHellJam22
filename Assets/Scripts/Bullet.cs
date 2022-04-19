using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float activeTime;
    void Update()
    {
        if(LevelTimer.levelRunning)
        {
        transform.position += transform.right * Time.deltaTime * speed;
        }
        Destroy(gameObject, activeTime);
    }
}
