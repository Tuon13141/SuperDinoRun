using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public AudioSource wingSound;

    private void Start()
    {
        StartCoroutine(StopWingSound());    
    }

    IEnumerator StopWingSound()
    {
        yield return new WaitUntil(() => gameObject.transform.position.x <= -6.5);
        wingSound.Stop();
    }
}
