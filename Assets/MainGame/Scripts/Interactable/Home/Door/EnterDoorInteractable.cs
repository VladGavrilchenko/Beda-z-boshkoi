using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDoorInteractable : SayingInteractive
{
    // Start is called before the first frame update
    void Start()
    {
        enabled = false;
    }

    public override void Interact()
    {
        base.Interact();
    }
}
