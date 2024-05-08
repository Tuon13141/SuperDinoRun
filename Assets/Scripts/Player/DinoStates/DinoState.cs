using System.Collections;
using System.Collections.Generic;

public abstract class DinoState 
{
    public Dino DinoPlayer { get; private set; }
    public void SetDino(Dino dino)
    {
        DinoPlayer = dino;
    }

    public abstract void ControllMovement();
}
