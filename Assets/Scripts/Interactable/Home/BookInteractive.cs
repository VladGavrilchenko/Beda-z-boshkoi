using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        base.Interact();

        isOpen = !isOpen;

        if (isOpen)
        {
            bookCanvas.gameObject.SetActive(true);
            iMove.SetIsMove(false);
        }
        else
        {
            bookCanvas.gameObject.SetActive(false);
            iMove.SetIsMove(true);
        }
    }
}
