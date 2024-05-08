using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckState : DinoState
{
    public override void ControllMovement()
    {
        if (DinoPlayer.Dino_RunAndJumpCollinder[0].enabled)
        {
            foreach(var item in DinoPlayer.Dino_RunAndJumpCollinder)
            {
                item.enabled = false;
            }
            
            DinoPlayer.Dino_DuckCollinder.enabled = true;
        }
        DinoPlayer.DinoAnimator.SetBool("Jump", false);
        DinoPlayer.DinoAnimator.SetBool("Duck", true);
    }

}
