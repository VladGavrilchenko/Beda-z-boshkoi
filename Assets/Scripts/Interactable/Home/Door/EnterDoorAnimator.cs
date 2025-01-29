using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDoorAnimator : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponentInParent<Animator>();
    }
    
    public void SetIsOpen(bool isOpen)
    {
        animator.SetBool("IsOpen", isOpen);
    }
}
