using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxSpeaker : MonoBehaviour
{
    [SerializeField] private Animator foxHadAnimator;
    private AudioSource audioSource;

    private void Awake()
    {
        foxHadAnimator.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        if(audioSource != null)
        {
            foxHadAnimator.gameObject.SetActive(true);
            audioSource.Play();
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

    }

    public void PlayeAudio(AudioClip playeClip)
    {
        audioSource.clip = playeClip;
        audioSource.Play();
    }
}
