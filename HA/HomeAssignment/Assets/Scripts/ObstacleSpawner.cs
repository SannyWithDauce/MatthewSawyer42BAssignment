﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigsList;

    [SerializeField] bool looping = false;

    int startingWave = 0;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnAllObstaclesInWave(WaveConfig waveToSpawn)
    {
        for (int obstacleCount = 1; obstacleCount <= waveToSpawn.GetNumberOfObstacles(); obstacleCount++)
        {
            var newObstacle = Instantiate(
                waveToSpawn.GetObstaclePreFab(),
                waveToSpawn.GetWaypointsList()[0].transform.position,
                Quaternion.identity);

            newObstacle.GetComponent<Pathing>().SetWaveConfig(waveToSpawn);

            yield return new WaitForSeconds(waveToSpawn.GetTimeBetweenSpawns());
        }
    }
    private IEnumerator SpawnAllWaves()
    {
        foreach (WaveConfig currentWave in waveConfigsList)
        {
            yield return new WaitForSeconds(1);
            yield return StartCoroutine(SpawnAllObstaclesInWave(currentWave));
        }
    }
}
