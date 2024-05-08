using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : DinoState
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
        DinoPlayer.DinoAnimator.SetBool("Jump", true);
        DinoPlayer.DinoAnimator.SetBool("Duck", false);
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.DownArrow))
        {
            DinoPlayer.rb.gravityScale = SpeedSetting.dino_heavyGravity;
        }
        else
        {
            DinoPlayer.rb.gravityScale = SpeedSetting.dino_Gravity;
        }
    }
}
