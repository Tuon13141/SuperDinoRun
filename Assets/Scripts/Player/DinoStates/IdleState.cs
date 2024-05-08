using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : DinoState
{
    public override void ControllMovement()
    {
        if (DinoPlayer.Dino_DuckCollinder.enabled)
        {
            foreach (var item in DinoPlayer.Dino_RunAndJumpCollinder)
            {
                item.enabled = true;
            }
            DinoPlayer.Dino_DuckCollinder.enabled = false;
        }
        DinoPlayer.rb.gravityScale = SpeedSetting.dino_Gravity;
        DinoPlayer.DinoAnimator.SetBool("Jump", false);
        DinoPlayer.DinoAnimator.SetBool("Duck", false);     
    }
}
