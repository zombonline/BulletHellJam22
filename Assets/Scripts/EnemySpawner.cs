﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    int startingWave = 0;
    [SerializeField] bool looping = false;
    public bool isSpawning;

    IEnumerator Start()
    {
            do
            {
                yield return StartCoroutine(SpawnAllWaves());
            }
            while (looping);
    }

    private IEnumerator SpawnAllWaves()
    {
        if (LevelTimer.levelRunning)
        {
            for (int waveIndex = startingWave; waveIndex < waveConfigs.Count; waveIndex++)
            {
                var currentWave = waveConfigs[waveIndex];
                yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
            }
        }
    }
    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int enemyCount = 0; enemyCount < waveConfig.GetNumberOfEnemies(); enemyCount++)
        {
            if ( isSpawning)
            {
                var newEnemy = Instantiate(waveConfig.GetEnemyPrefab(),
                     waveConfig.GetWaypoints()[0].transform.position, Quaternion.identity);
                newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);
            }
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
    }
}
