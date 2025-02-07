using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitMimickActivator : MimickActivator
{
    private bool wasPlayerClose;

    private void Start()
    {
        playerTransform = FindAnyObjectByType<PlayerMover>().transform;
    }

    private void Update()
    {
        if (isStartSpawn)
        {
            return;
        }

        distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
        bool isPlayerBeside = distanceToPlayer <= minRangeToSearch;

        if (wasPlayerClose && !isPlayerBeside)
        {
            if (CanSeePlayer())
            {
                isStartSpawn = true;
                StartCoroutine(SpawnMonsterWithDelay());
            }
        }

        wasPlayerClose = isPlayerBeside;
    }

  
}