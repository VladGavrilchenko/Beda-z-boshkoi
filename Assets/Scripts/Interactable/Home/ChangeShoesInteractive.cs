using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeShoesInteractive : SayingInteractive
{
    [SerializeField] private float speedScale;
    [SerializeField] private GameObject newShoes;

    private void Start()
    {
        newShoes.SetActive(false);
    }

    public override void Interact()
    {
        base.Interact();
        FindAnyObjectByType<PlayerMover>().SetSpeedScale(speedScale);
        gameObject.SetActive(false);
        newShoes.SetActive(true);
    }
}
