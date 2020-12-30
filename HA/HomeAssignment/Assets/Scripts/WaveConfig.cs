using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject obstaclePrefab;

    [SerializeField] GameObject pathPrefab;

    [SerializeField] float timeBetweenSpawns = 1f;

    [SerializeField] int numberOfEnemies = 5;

    [SerializeField] float enemyMoveSpeed = 3f;
    // Start is called before the first frame update
    public GameObject GetEnemyPreFab()
    {
        return obstaclePrefab;
    }
    public List<Transform> GetWaypointsList()
    {
        var waveWaypoints = new List<Transform>();

        foreach (Transform child in pathPrefab.transform)
        {
            waveWaypoints.Add(child);
        }

        return waveWaypoints;
    }
    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }
    public int GetNumberOfEnemies()
    {
        return numberOfEnemies;
    }
    public float GetEnemyMoveSpeed()
    {
        return enemyMoveSpeed;
    }
}
