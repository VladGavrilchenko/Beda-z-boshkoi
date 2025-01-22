using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SayingInteractive : Interactive
{
    [SerializeField] private AudioClip say;

    private void Start()
    {
        enabled = false;
    }

    public override void Interact()
    {
        base.Interact();

        if (FindFirstObjectByType<FoxSpeaker>() == false)
        {
            return;
        }

        FindFirstObjectByType<FoxSpeaker>().PlayeAudio(say);
    }

}
