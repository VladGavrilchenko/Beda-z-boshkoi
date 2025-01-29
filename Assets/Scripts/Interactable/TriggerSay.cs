using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSay: MonoBehaviour
{
    [SerializeField] protected AudioClip say;
    [SerializeField] protected string sayText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindFirstObjectByType<FoxSpeaker>().PlayeAudio(say, sayText);
        }
    }
}
