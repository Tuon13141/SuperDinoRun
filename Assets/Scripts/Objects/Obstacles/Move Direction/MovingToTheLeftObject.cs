using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingToTheLeftObject : MovingObject
{
    public MovingToTheLeftObject(float speed) : base(speed)
    {
    }

    public MovingToTheLeftObject(float speed, GameObject gameObject) : base(speed, gameObject)
    {
    }

    public override void Move()
    {
        //Debug.Log("left");
        GameObject.transform.Translate(Vector2.left * Speed * Time.deltaTime);
    }
}
