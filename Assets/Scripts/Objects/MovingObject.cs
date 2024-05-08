using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovingObject
{
    public float Speed { protected get; set; }
    public GameObject GameObject { protected get; set; }

    public MovingObject() { }
    public MovingObject(float speed)
    {
        Speed = speed;
    }

    public MovingObject(float speed, GameObject gameObject)
    {
        Speed = speed;
        GameObject = gameObject;
    }
    public abstract void Move();
}
