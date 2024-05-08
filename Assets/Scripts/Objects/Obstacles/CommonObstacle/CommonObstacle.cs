using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CommonObstacle : Obstacle
{
    [SerializeField]
    protected List<float> xList;
    [SerializeField]
    protected List<float> yList;

    public bool cooldown = false;
    protected void SetPosition()
    { 
        this.transform.position = new Vector2(xList[Random.Range(0, xList.Count)], yList[Random.Range(0, yList.Count)]);
    }
}
