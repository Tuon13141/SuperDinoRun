using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingToTheRightCommonObstacle : CommonObstacle
{
    void Start()
    {
        StartCoroutine(SelfDestroyAfterGoingOffScreen());
        SetMovingObject(new FallingToTheRightObject(SpeedSetting.fallingSpeed));
        SetPosition();
    }
}
