using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingToTheRightObject : MovingObject
{
    public override void Move()
    {
        GameObject.transform.Translate(new Vector2(1, -1) * Speed * Time.deltaTime);
    }

    public FallingToTheRightObject(float speed) : base(speed)
    {
    }

    public FallingToTheRightObject(float speed, GameObject gameObject) : base(speed, gameObject)
    {
    }

}
