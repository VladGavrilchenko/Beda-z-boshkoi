using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hatch : Action
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float closeRange;
    private Animator animator;

    public override void Active()
    {
        playerTransform = FindAnyObjectByType<PlayerMover>().transform;
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, playerTransform.position) > closeRange)
        {
            animator.SetTrigger("Move");
            Destroy(this);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, closeRange);
    }


}
