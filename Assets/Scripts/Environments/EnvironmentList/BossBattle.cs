using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBattle : Environment
{
    public BossBattle(List<Sprite> backgroundList, List<GameObject> obstacles) : base(backgroundList, obstacles)
    {
    }

    public override GameObject SetObstacle()
    {
        GameObject obs = obstacles[Random.Range(0, obstacles.Count)];

        obs.GetComponent<Obstacle>().SetMovingObject(new MovingLoopObject(SpeedSetting.movingLoopSpeed));
        return obs;
    }
}
