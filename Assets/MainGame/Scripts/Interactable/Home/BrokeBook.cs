using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokeBook : MonoBehaviour
{
    [SerializeField] private Animator bookAnimator;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            bookAnimator.SetTrigger("Broke");
            Destroy(gameObject);
        }
    }
}
