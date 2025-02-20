using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBeside : MonoBehaviour
{
    [SerializeField] private float detectionRange = 5f;
    private Transform player;
    private bool isNear;

    private void OnEnable()
    {
        player = FindAnyObjectByType<PlayerMover>().transform;
        isNear = IsPlayerNear();
    }

    private void Start()
    {
        player = FindAnyObjectByType<PlayerMover>().transform;
    }

    private void Update()
    {
        isNear = IsPlayerNear();
    }

    bool IsPlayerNear()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        return distance <= detectionRange;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }

    public bool IsNear()
    {
        return isNear;  
    }
}
