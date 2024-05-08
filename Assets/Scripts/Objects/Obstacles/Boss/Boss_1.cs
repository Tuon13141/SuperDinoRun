using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_1 : CommonObstacle
{
    [SerializeField]
    private int maxLooping = 5;
    [SerializeField]
    private int loopingCount;
    public List<BoxCollider2D> BossCollinder;
    public Animator animator;

    public AudioSource breathingSound;

    void Start()
    {
        StartCoroutine(SelfDestroyAfterGoingOffScreen());
        SetPosition();
    }

    protected override IEnumerator SelfDestroyAfterGoingOffScreen()
    {
        StartCoroutine(IncreaseLoopingCount());
        yield return new WaitUntil(() => loopingCount == maxLooping);
        animator.SetBool("Over", true);
        cooldown = true;
        foreach (var item in BossCollinder)
        {
            item.enabled = false;
        }
        breathingSound.Play();
        yield return new WaitUntil(() => this.transform.position.x <= -7);
        Destroy(gameObject);
    }

    IEnumerator IncreaseLoopingCount()
    {
        if(loopingCount == maxLooping) {
            StopCoroutine(IncreaseLoopingCount());
            yield break;
        }
        yield return new WaitUntil(() => this.transform.position.x >= 7 || this.transform.position.x <= -7);
      
        loopingCount++;
        StartCoroutine(IncreaseLoopingCount());
    }
}
