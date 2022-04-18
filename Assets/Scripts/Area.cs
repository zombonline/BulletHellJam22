using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    public float timeInArea = 0, totalTime = 0;
    public bool timeStarted = false, playerInArea = true;

    private void Update()
    {
        if(timeStarted)
        {
            totalTime += Time.deltaTime;
            if(playerInArea)
            {
                timeInArea += Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerInArea = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInArea = false;
        }
    }
}
