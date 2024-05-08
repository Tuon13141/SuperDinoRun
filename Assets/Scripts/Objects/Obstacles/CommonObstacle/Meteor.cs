using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public GameObject boom;
    public GameObject rock;

    private void Start()
    {
        StartCoroutine(SpawnBoomAndRockAfterTouchTheGround());
    }

    protected IEnumerator SpawnBoomAndRockAfterTouchTheGround()
    {
        yield return new WaitUntil(() => transform.position.y <= -0.76);

        this.GetComponent<SpriteRenderer>().sortingOrder = -1;
        GameObject b = Instantiate(boom);
        b.transform.position = new Vector2(this.transform.position.x, -1.1f);
        b.GetComponent<Obstacle>().SetMovingObject(new MovingToTheLeftObject(SpeedSetting.movingToLeftSpeed));

        yield return new WaitForSeconds(0.5f);
  
        GameObject r = Instantiate(rock);
        r.transform.position = new Vector2(b.transform.position.x, -0.66f);
        Destroy(b);
        r.GetComponent<Obstacle>().SetMovingObject(new MovingToTheLeftObject(SpeedSetting.movingToLeftSpeed));
        this.GetComponent<CommonObstacle>().cooldown = true;
    }

}
