using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseEnterDoor : MonoBehaviour
{
    [SerializeField] private Animator doorAnimator;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            doorAnimator.SetBool("IsOpen" , false);
            Destroy(gameObject);
        }
    }
}
