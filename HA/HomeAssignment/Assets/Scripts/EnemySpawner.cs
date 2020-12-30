using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
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

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveToSpawn)
    {
        for (int enemyCount = 1; enemyCount <= waveToSpawn.GetNumberOfEnemies(); enemyCount++)
        {
            var newEnemy = Instantiate(
                waveToSpawn.GetEnemyPreFab(),
                waveToSpawn.GetWaypointsList()[0].transform.position,
                Quaternion.identity);

            newEnemy.GetComponent<Pathing>().SetWaveConfig(waveToSpawn);

            yield return new WaitForSeconds(waveToSpawn.GetTimeBetweenSpawns());
        }
    }
    private IEnumerator SpawnAllWaves()
    {
        foreach (WaveConfig currentWave in waveConfigsList)
        {
            yield return new WaitForSeconds(1);
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }
}
