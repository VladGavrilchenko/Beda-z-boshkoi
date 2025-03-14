using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletDoorInteractive : Interactive
{
    [SerializeField] private GameObject activeEnemy;
    [SerializeField] private AudioClip knockClip;
    [SerializeField] private int maxKnockCount;
    private AudioSource audioSource;
    private Animator animator;
    private int knockCount;

    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = knockClip;
        activeEnemy.SetActive(false);
    }


    public override void Interact()
    {
        base.Interact();

        if (audioSource.isPlaying)
        {
            return;
        }

        audioSource.Play();
        knockCount++;

        if (knockCount >= maxKnockCount)
        {
            animator.SetTrigger("Broken");
        }
    }

    public void ActivEnemy()
    {
        activeEnemy.SetActive(true);
    }
}
