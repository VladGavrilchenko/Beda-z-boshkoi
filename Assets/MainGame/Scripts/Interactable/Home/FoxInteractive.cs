using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FoxInteractive : Interactive
{
    [SerializeField] private string sayOnLeave;
    [SerializeField] private TMP_Text sayText;
    [SerializeField] private SayingInteractive[] blockSayingInteractives;
    [SerializeField] private AudioClip sayClip;
    private FoxSpeaker foxSpeaker;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        foreach (SayingInteractive say in blockSayingInteractives)
        {
            say.GetComponent<Collider>().enabled = false;
        }
        foxSpeaker = FindAnyObjectByType<FoxSpeaker>();
        foxSpeaker.enabled = false;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        sayText.gameObject.SetActive(audioSource.isPlaying);
    }

    public override void Interact()
    {
        base.Interact();
        foxSpeaker.enabled = true;
        Destroy(gameObject);

        FindAnyObjectByType<GameManager>().SetNextMission(1);

        foreach (SayingInteractive say in blockSayingInteractives)
        {
            say.GetComponent<Collider>().enabled = true;
        }
    }

    public void PlaySay()
    {
        if (audioSource.isPlaying == false)
        {
            sayText.text = sayOnLeave;
            audioSource.clip = sayClip;
            audioSource.Play();
        }
    }
}
