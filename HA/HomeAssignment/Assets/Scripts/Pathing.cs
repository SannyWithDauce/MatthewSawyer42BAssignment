using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathing : MonoBehaviour
{

    [SerializeField] List<Transform> waypoints;

    [SerializeField] float obstaclemovespeed = 2.5f;

    [SerializeField] WaveConfig waveConfig;

    [SerializeField] int scoreValue = 5;

    int waypointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        waypoints = waveConfig.GetWaypointsList();

        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        ObstacleMove();
    }

    private void ObstacleMove()
    {
        if (waypointIndex <= waypoints.Count - 1){ 
            var targetPosition = waypoints[waypointIndex].transform.position;

            targetPosition.z = 0f;

            var obstacleMovement = waveConfig.GetObstacleMoveSpeed() * Time.deltaTime;

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, obstacleMovement);

            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
            FindObjectOfType<GameSession>().AddToScore(scoreValue);
        }
    }

    public void SetWaveConfig(WaveConfig waveConfigToSet)
    {
        waveConfig = waveConfigToSet;
    }
}
