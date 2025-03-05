using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDoorInteractive : Interactive
{
    private FoxSpeaker foxSpeaker;
    private FoxInteractive foxInteractive;
    private void Start()
    {
        foxSpeaker = FindFirstObjectByType<FoxSpeaker>();
        foxInteractive = FindFirstObjectByType<FoxInteractive>();
    }

    public override void Interact()
    {
        base.Interact();

        if (foxSpeaker.enabled)
        {
            GetComponentInParent<Animator>().SetTrigger("Open");
            Destroy(this);
        }
        else
        {
            foxInteractive.PlaySay();
        }
    }
}
