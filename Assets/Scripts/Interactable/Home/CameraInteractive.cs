using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInteractive : SayingInteractive
{
    [SerializeField] private AudioClip altSayClip;
    [SerializeField] private string altSayText;
    private OldCamera oldCamera;
    private bool isAltSay;

    private void Awake()
    {
        oldCamera = FindAnyObjectByType<OldCamera>();
    }

    public override void Interact()
    {

        if (FindFirstObjectByType<FoxSpeaker>() == false)
        {
            return;
        }

        if (isAltSay)
        {
            FindFirstObjectByType<FoxSpeaker>().PlayeAudio(altSayClip, altSayText);
        }
        else
        {
            FindFirstObjectByType<FoxSpeaker>().PlayeAudio(say, sayText);
        }


        Destroy(gameObject);
        oldCamera.enabled = true;
    }

    public void SetAltSay(bool isAltSay)
    {
        this.isAltSay = isAltSay;
    }
}