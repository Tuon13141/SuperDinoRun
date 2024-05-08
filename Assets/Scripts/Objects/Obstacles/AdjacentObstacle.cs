using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjacentObstacle : Obstacle
{
    [SerializeField]
    protected int maxObstacle = ObstacleSetting.maxObstacle;
    [SerializeField]
    protected int minObstacle = ObstacleSetting.minObstacle;
    [SerializeField]
    protected float spaceBetweenObstacle;
    [SerializeField]
    protected float cooldownTimeAfterSpawnAdjacentObstacle;

    protected int obstacleCount;

    public GameObject Obstacle;

    private void Start()
    {
        SpawnObstacalInAdjacentObstacle();
        StartCoroutine(SelfDestroyAfterGoingOffScreen());
    }
    public float getCooldownTimeAfterSpawnAdjacentObstacle() { return cooldownTimeAfterSpawnAdjacentObstacle; }
    public float SpaceBetweenObstacle { get; set; }
    protected void SpawnObstacalInAdjacentObstacle()
    {
        obstacleCount = Random.Range(minObstacle, maxObstacle);
        
        for(int i = 0; i < obstacleCount; i++)
        {      
            SetupForObstacleInAdjacentObstacle(Obstacle, i);
        }
    }

    protected void SetupForObstacleInAdjacentObstacle(GameObject obstacle, int i)
    {
        GameObject obs = Instantiate(obstacle);
        obs.GetComponent<Obstacle>().SetMovingObject(new StayStill());
        obs.transform.position = new Vector2(this.transform.position.x + i * spaceBetweenObstacle, this.transform.position.y);
        obs.transform.SetParent(this.transform);
    }
}
