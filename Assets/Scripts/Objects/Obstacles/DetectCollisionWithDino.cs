using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectCollisionWithDino : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Dino")
        {
            //Debug.Log("Trigger");
            GameObject deadDino = Instantiate(collision.GetComponent<Dino>().DeadDino);
            deadDino.transform.position = new Vector2(collision.transform.position.x, collision.transform.position.y);
            Destroy(collision.gameObject);
        }
            
    }
}
