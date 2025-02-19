using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySerch : MonoBehaviour
{
    [SerializeField] private float serchRange = 5f;
    private Transform player;
    private bool isNear;

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
        return distance <= serchRange;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, serchRange);
    }

    public bool IsNear()
    {
        return isNear;
    }
}
