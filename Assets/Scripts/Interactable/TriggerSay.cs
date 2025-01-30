using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSay: MonoBehaviour
{
    [SerializeField] private AudioClip say;
    [SerializeField] private string sayText;
    [SerializeField] private float timeStop;

    private float lostInteractiveTime = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Time.time > timeStop + lostInteractiveTime)
        {
            lostInteractiveTime = Time.time;
            FindFirstObjectByType<FoxSpeaker>().PlayeAudio(say, sayText);
        }
    }
}
