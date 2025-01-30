using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitInteractive : Interactive
{
    [SerializeField] private AudioClip sayTakeMedicine;
    [SerializeField] private AudioClip sayTakeCamera;
    [SerializeField] private AudioClip sayTakeMedicineAndCamera;
    [SerializeField] private string sayTextTakeMedicine;
    [SerializeField] private string sayTextTakeCamera;
    [SerializeField] private string sayTextTakeMedicineAndCamera;
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
            foxSpeaker.PlayeAudio(sayTakeMedicineAndCamera , sayTextTakeMedicineAndCamera);
            FindAnyObjectByType<GameManager>().SetNextMission(2);
            return;
        }
        else if (FindAnyObjectByType<OldCamera>().enabled == false)
        {
            Debug.Log("We need Camera");
            foxSpeaker.PlayeAudio(sayTakeCamera, sayTextTakeCamera);

            FindAnyObjectByType<GameManager>().SetNextMission(3);

            return;
        }
        else if (FindAnyObjectByType<MoralHealth>().enabled == false)
        {
            Debug.Log("We need Moral");
            foxSpeaker.PlayeAudio(sayTakeMedicine, sayTextTakeMedicine);

            FindAnyObjectByType<GameManager>().SetNextMission(4);

            return;
        }

        enterDoorAnimator.SetIsOpen(true);

        Destroy(this);
    }

}
