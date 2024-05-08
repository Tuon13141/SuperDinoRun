using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public MovingObject MovingObject { get; protected set; }

    public void SetMovingObject(MovingObject movingObject)
    {
        //Debug.Log("setting");
        MovingObject = movingObject;
        movingObject.GameObject = gameObject;

    }

    private void Start()
    {
        StartCoroutine(SelfDestroyAfterGoingOffScreen());
    }
    private void Update()
    {
        MovingObject.Move();
    }

    protected virtual IEnumerator SelfDestroyAfterGoingOffScreen()
    {
        yield return new WaitUntil(() => transform.position.x <= -16 || transform.position.y <= -4);
        Destroy(gameObject);
    }
}
