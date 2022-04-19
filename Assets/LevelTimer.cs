using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    [SerializeField] float levelLength = 60;
    public static bool levelRunning = false;
    float timeRemaining;
    [SerializeField] Canvas levelFinishCanvas;
    

    private void Awake()
    {
        timeRemaining = levelLength;
    }

    private void Update()
    {
        if(Input.anyKeyDown)
        {
            levelRunning = true;
        }
        if(levelRunning)
        {
            timeRemaining -= Time.deltaTime;
            if(timeRemaining <= 0)
            {
                FindObjectOfType<EnemySpawner>().isSpawning = false;
                if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
                {
                    levelRunning = false;
                    levelFinishCanvas.gameObject.SetActive(true);
                }
            }
        }

        
    }
}
