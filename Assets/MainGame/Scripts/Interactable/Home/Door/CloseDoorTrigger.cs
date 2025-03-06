using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoorTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindAnyObjectByType<EnterDoorAnimator>().SetIsOpen(false);
            CloseDoorTrigger[] allCloseTrigger = FindObjectsOfType<CloseDoorTrigger>();

            foreach (CloseDoorTrigger trigger in allCloseTrigger)
            {
                trigger.gameObject.SetActive(false);
            }
            FindObjectOfType<EnterDoorInteractable>().enabled = true;
            FindAnyObjectByType<ToyManager>().StartFinding();
            Destroy(FindAnyObjectByType<GoOutideTrigger>().gameObject);
        }
    }
}
