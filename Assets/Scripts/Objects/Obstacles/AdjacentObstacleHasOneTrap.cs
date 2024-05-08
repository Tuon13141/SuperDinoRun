using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjacentObstacleHasOneTrap : AdjacentObstacle
{
    public GameObject TrapObstacle;

    private void Start()
    {
        SpawnObstacalInAdjacentObstacle();
        SpawnTrapObstacle();
        StartCoroutine(SelfDestroyAfterGoingOffScreen());
    }
    public void SpawnTrapObstacle()
    {
        int randomPos = Random.Range(0, obstacleCount);

        SetupForObstacleInAdjacentObstacle(TrapObstacle, randomPos);
    }
}
