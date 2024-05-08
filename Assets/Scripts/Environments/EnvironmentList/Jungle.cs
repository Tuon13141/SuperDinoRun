using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jungle : Environment
{
    public Jungle(List<Sprite> backgroundList, List<GameObject> obstacles) : base(backgroundList, obstacles)
    {
    }

    public override GameObject SetObstacle()
    {
        GameObject obs = obstacles[Random.Range(0, obstacles.Count)];

        obs.GetComponent<Obstacle>().SetMovingObject(new MovingToTheLeftObject(SpeedSetting.movingToLeftSpeed));
        return obs;
    }
}
