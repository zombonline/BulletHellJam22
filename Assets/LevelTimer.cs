using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    [SerializeField] float levelLength = 60;
    bool levelStarted = false;
    float timeRemaining;

    private void Awake()
    {
        timeRemaining = levelLength;
    }

    private void Update()
    {
        if(Input.anyKeyDown)
        {
            levelStarted = true;
            FindObjectOfType<Area>().timeStarted = true;
        }
        if(levelStarted)
        {
            timeRemaining -= Time.deltaTime;
            if(timeRemaining <= 0)
            {
                FindObjectOfType<Area>().timeStarted = false;
                FindObjectOfType<EnemySpawner>().
            }
        }
    }
}
