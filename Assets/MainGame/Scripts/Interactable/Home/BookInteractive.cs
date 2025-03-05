using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.LookDev;

public class BookInteractive : SayingInteractive
{
    [SerializeField] private Canvas bookCanvas;
    private bool isOpen;
    private IMove iMove;

    private void Start()
    {
        bookCanvas.gameObject.SetActive(false);
        iMove = FindAnyObjectByType<PlayerMover>().GetComponent<IMove>();
    }

    public override void Interact()
    {
        if (FindFirstObjectByType<FoxSpeaker>() == false)
        {
            return;
        }

        isOpen = !isOpen;

        if (isOpen)
        {
            bookCanvas.gameObject.SetActive(true);
            iMove.SetIsMove(false);
            FindFirstObjectByType<FoxSpeaker>().PlayeAudio(say, sayText);
        }
        else
        {
            bookCanvas.gameObject.SetActive(false);
            iMove.SetIsMove(true);
        }

        if (FindAnyObjectByType<CameraInteractive>() != null)
        {
            FindAnyObjectByType<CameraInteractive>().SetAltSay(true);
        }


    }
}
