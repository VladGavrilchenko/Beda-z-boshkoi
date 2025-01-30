using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GmomeSpawnerTrigger : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private GameObject gnomeSpawnerPref;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(gnomeSpawnerPref, playerTransform.position, Quaternion.identity);
            Destroy(this);
        }
    }
}
