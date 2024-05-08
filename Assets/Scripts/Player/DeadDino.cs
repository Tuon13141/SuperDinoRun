using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadDino : MonoBehaviour
{
    public Rigidbody2D rb;
    void Start()
    {
        rb.AddForce(Vector2.up * 7f, ForceMode2D.Impulse);
        StartCoroutine(GameOverScene());
    }


    IEnumerator GameOverScene()
    {
        yield return new WaitUntil(() => gameObject.transform.position.y <= -4);

        SceneManager.LoadScene("GameOverScene");
        SpeedSetting.movingLoopSpeed = 0;
        SpeedSetting.movingToLeftSpeed = 0;
        
        Destroy(gameObject);
    }
}
