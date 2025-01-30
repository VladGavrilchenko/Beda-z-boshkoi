using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoOutideTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindAnyObjectByType<GameManager>().SetNextMission(5);
        }
    }
}
