using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FoxSpeaker : MonoBehaviour
{
    [SerializeField] private GameObject foxHadUI;
    [SerializeField] private Animator foxHadAnimator;
    [SerializeField] private TMP_Text text;
    [SerializeField] private GameObject textObject;
    private AudioSource audioSource;

    private void Awake()
    {
        foxHadUI.SetActive(false);
        textObject.SetActive(false);
    }

    private void OnEnable()
    {
        if(audioSource != null)
        {
            foxHadUI.SetActive(true);
            audioSource.Play();
            textObject.SetActive(true);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();    
    }

    private void Update()
    {
        if (foxHadAnimator.gameObject.activeSelf == false)
        {
            return;
        }

        foxHadAnimator.SetBool("IsSpeak", audioSource.isPlaying);

        if (audioSource.isPlaying == false && text.gameObject.activeSelf)
        {
            text.gameObject.SetActive(false);
            textObject.SetActive(false);
        }

    }

    public void PlayeAudio(AudioClip playeClip, string sayText)
    {
        audioSource.clip = playeClip;
        audioSource.Play();
        text.text = sayText;
        text.gameObject.SetActive(true);
        textObject.SetActive(true);
    }
}
