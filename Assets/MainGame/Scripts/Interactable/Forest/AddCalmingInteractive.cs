using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCalmingInteractive : SayingInteractive
{
    [SerializeField] private int countHeal;
    public override void Interact()
    {
        base.Interact();
        FindAnyObjectByType<MoralHealth>().AddCountHealth(countHeal);
        Destroy(gameObject);
    }
}
