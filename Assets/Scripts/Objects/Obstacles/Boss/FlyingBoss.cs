using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlyingBoss : MonoBehaviour
{
    public Boss_1 boss;
    public float speed;
    public GameObject dropStone;

    public AudioSource flyingSound;

    private void Start()
    {
        boss.MovingObject.Speed = speed;
        StartCoroutine(DropStone());
    }

    IEnumerator DropStone()
    {
        if(boss.cooldown == true)
        {
            yield break;
        }
       
        yield return new WaitForSeconds(0.75f);
        GameObject stone = Instantiate(dropStone);
        stone.transform.position = new Vector3(gameObject.transform.position.x - 0.4f, gameObject.transform.position.y - 0.4f);
        stone.GetComponent<Obstacle>().SetMovingObject(new StayStill());
        flyingSound.Play();
        StartCoroutine(DropStone());
    }
}
