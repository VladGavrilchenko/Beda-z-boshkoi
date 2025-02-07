using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInteractive : SayingInteractive
{
    [SerializeField] private AudioClip altSayClip;
    [SerializeField] private string altSayText;
    [SerializeField] private PhotoCamera oldCamera;
    private bool isAltSay;

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

        if (FindAnyObjectByType<GameManager>().GetCurrentMission() == 2)
        {
            FindAnyObjectByType<GameManager>().SetNextMission(4);
        }
        else if (FindAnyObjectByType<GameManager>().GetCurrentMission() == 3)
        {
            FindAnyObjectByType<GameManager>().SetNextMission(5);
        }

        oldCamera = FindAnyObjectByType<PhotoCamera>(); 
        Destroy(gameObject);
        oldCamera.SetActive(true);
        oldCamera.enabled = true;
    }

    public void SetAltSay(bool isAltSay)
    {
        this.isAltSay = isAltSay;
    }
}
