using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingToTheLeftCommonObstacle : CommonObstacle
{
    // Start is called before the first frame update
    void Start()
    {
        cooldown = true;
        StartCoroutine(SelfDestroyAfterGoingOffScreen());
        SetMovingObject(new MovingToTheLeftObject(SpeedSetting.movingToLeftSpeed));
        SetPosition();
    }

}
