using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalmingInteractive : SayingInteractive
{
    private MoralHealth moralHealth;

    private void Awake()
    {
        moralHealth = FindAnyObjectByType<MoralHealth>();
    }

    public override void Interact()
    {
        
        base.Interact();
        Destroy(gameObject);
        moralHealth.enabled = true;

        if(FindAnyObjectByType<GameManager>().GetCurrentMission() == 2)
        {
            FindAnyObjectByType<GameManager>().SetNextMission(3);
        }
        else if(FindAnyObjectByType<GameManager>().GetCurrentMission() == 4)
        {
            FindAnyObjectByType<GameManager>().SetNextMission(5);
        }
    }
}
