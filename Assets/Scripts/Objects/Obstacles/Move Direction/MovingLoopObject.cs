using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingLoopObject : MovingObject
{
    public bool MoveToTheLeft { get; set; } = true;
    public MovingLoopObject(float speed) : base(speed)
    {
    }

    public MovingLoopObject(float speed, GameObject gameObject) : base(speed, gameObject)
    {
    }
    public override void Move()
    {
        if(!MoveToTheLeft)
        {
            GameObject.transform.Translate(Vector2.right * Speed * Time.deltaTime);
            GameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else 
        {
            GameObject.transform.Translate(Vector2.left * Speed * Time.deltaTime);
            GameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        if (GameObject.transform.position.x > 7)
        {
            //Debug.Log("left");
            MoveToTheLeft = true;
        }
        else if (GameObject.transform.position.x < -7)
        {
            //Debug.Log("right");
            MoveToTheLeft = false;
        }
    }
}
