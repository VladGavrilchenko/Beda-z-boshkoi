using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToGraveTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GoToGraveTrigger[] allCloseTrigger = FindObjectsOfType<GoToGraveTrigger>();

            foreach (GoToGraveTrigger trigger in allCloseTrigger)
            {
                trigger.gameObject.SetActive(false);
            }

            FindAnyObjectByType<GameManager>().SetNextMission(7);
            Destroy(gameObject);
        }
    }
}
