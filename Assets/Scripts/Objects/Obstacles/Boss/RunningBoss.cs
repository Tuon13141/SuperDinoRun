using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningBoss : MonoBehaviour
{
    public Boss_1 boss;
    public ParticleSystem RunParticle;
    public AudioSource runningSound;

    void Start()
    {
        StartCoroutine(StopRunningSound());
    }
    IEnumerator StopRunningSound()
    {
        yield return new WaitUntil(() => boss.cooldown == true);
        runningSound.Stop();
        RunParticle.Stop();
    }
}
