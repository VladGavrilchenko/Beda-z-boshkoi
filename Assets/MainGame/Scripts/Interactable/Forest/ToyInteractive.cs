using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyInteractive : SayingInteractive
{
    [SerializeField] private List<MimicRandomizer> mimicRandomizers = new List<MimicRandomizer>();
    [SerializeField] private Action[] actions;

    private void Awake()
    {
        for (int i = 0; i < mimicRandomizers.Count; i++)
        {
            mimicRandomizers[i].DisableMimick();
            mimicRandomizers[i].enabled =false;
        }
    }


    public override void Interact()
    {
        base.Interact();

        if (mimicRandomizers != null)
        {
            for (int i = 0; i < mimicRandomizers.Count; i++)
            {
                mimicRandomizers[i].enabled = true;
                mimicRandomizers[i].ActiveMimick();
            }
        }

        if (actions != null)
        {
            for (int i = 0; i < actions.Length; i++)
            {
                actions[i].enabled = true;
                actions[i].Active();
            }
        }

        FindAnyObjectByType<ToyManager>().AddToCount();
        Destroy(gameObject);
    }
}
