using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPhotoInteractive : SayingInteractive
{
    [SerializeField] private int countPhoto;

    public override void Interact()
    {
        base.Interact();
        FindAnyObjectByType<PhotoCamera>().AddCountPhoto(countPhoto);
        Destroy(gameObject);
    }
}
