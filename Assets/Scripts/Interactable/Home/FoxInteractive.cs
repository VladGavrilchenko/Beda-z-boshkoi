using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.LookDev;

public class FoxInteractive : Interactive
{
    [SerializeField] private SayingInteractive[] blockSayingInteractives;
    [SerializeField] private AudioClip[] saysClip;
    private PlayerDoorInteractive doorInteractive;
    private FoxSpeaker foxSpeaker;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        foreach (SayingInteractive say in blockSayingInteractives)
        {
            say.GetComponent<Collider>().enabled = false;
        }

        doorInteractive = FindAnyObjectByType<PlayerDoorInteractive>();
        foxSpeaker = FindAnyObjectByType<FoxSpeaker>();
        foxSpeaker.enabled = false;
        audioSource = GetComponent<AudioSource>();
    }

    public override void Interact()
    {
        base.Interact();
        foxSpeaker.enabled = true;
        Destroy(gameObject);

        foreach (SayingInteractive say in blockSayingInteractives)
        {
            say.GetComponent<Collider>().enabled = true;
        }
    }

    public void PlaySay()
    {
        if (audioSource.isPlaying == false)
        {
            audioSource.clip = saysClip[0];
            audioSource.Play();
        }
    }
}
