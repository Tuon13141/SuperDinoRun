using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingToTheLeftObject : MovingObject
{
    public override void Move()
    {
        GameObject.transform.Translate(new Vector2(-1, -1) * Speed * Time.deltaTime);
    }

    public FallingToTheLeftObject(float speed) : base(speed)
    {

    }

    public FallingToTheLeftObject(float speed, GameObject gameObject) : base(speed, gameObject)
    {
    }
}
