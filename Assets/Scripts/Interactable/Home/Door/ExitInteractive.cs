using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitInteractive : SayingInteractive
{
    [SerializeField] private AudioClip sayTakeMedicine;
    [SerializeField] private AudioClip sayTakeCamera;
    [SerializeField] private AudioClip sayTakeMedicineAndCamera;
    private FoxSpeaker foxSpeaker;
    private EnterDoorAnimator enterDoorAnimator;

    private void Start()
    {
        enterDoorAnimator = GetComponentInParent<EnterDoorAnimator>();
        foxSpeaker = FindAnyObjectByType<FoxSpeaker>();
    }

    public override void Interact()
    {
        if(FindAnyObjectByType<OldCamera>().enabled == false && FindAnyObjectByType<MoralHealth>().enabled == false)
        {
            Debug.Log("We need Camera and Moral");
            return;
        }
        else if (FindAnyObjectByType<OldCamera>().enabled == false)
        {
            Debug.Log("We need Camera");
            return;
        }
        else if (FindAnyObjectByType<MoralHealth>().enabled == false)
        {
            Debug.Log("We need Moral");
            return;
        }

        enterDoorAnimator.SetIsOpen(true);

        Destroy(this);
    }

}
