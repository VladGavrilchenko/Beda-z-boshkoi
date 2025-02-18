using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    [SerializeField] private float visionRange = 10f;
    [SerializeField] private float visionAngle = 60f;
    [SerializeField] private LayerMask obstacleMask;
    private Transform player;
    private bool isSeePlayer;

    private void Start()
    {
        player = FindAnyObjectByType<PlayerMover>().transform;
    }

    private void FixedUpdate()
    {
        isSeePlayer = CanSeePlayer();
    }

    private bool CanSeePlayer()
    {
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);

        if (angleToPlayer < visionAngle / 2)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, directionToPlayer, out hit, visionRange))
            {
                if (hit.transform == player)
                {
                    Debug.DrawLine(transform.position, player.position, Color.green);
                    return true;
                }
                else
                {
                    Debug.DrawLine(transform.position, hit.point, Color.red);
                }
            }
        }

        Debug.DrawRay(transform.position, transform.forward * visionRange, Color.blue);
        return false;
    }

    public bool IsSeePlayer()
    {
        return isSeePlayer;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRange);
    }
}
