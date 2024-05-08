using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingToTheLeftCommonObstacle : CommonObstacle
{
    void Start()
    {
        StartCoroutine(SelfDestroyAfterGoingOffScreen());
        SetMovingObject(new FallingToTheLeftObject(SpeedSetting.fallingSpeed));
        SetPosition();
    }
}
