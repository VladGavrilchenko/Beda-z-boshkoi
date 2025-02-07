using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyInteractive : SayingInteractive
{
    public override void Interact()
    {
        base.Interact();
        Destroy(gameObject);
    }
}
