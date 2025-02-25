using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitScreamState : RabbitState
{
    private const float checkInterval = 1f;
    private float checkTimer = 0f;

    public override void EnterState(RabbitStateManager rabbit)
    {
        rabbit.enemyAI.SetIsStop(true);
        rabbit.enemyBeside.enabled = false;
        rabbit.enemyVision.enabled = false;
        rabbit.enemySerch.enabled = true;
    }

    public override void OnUpdateState(RabbitStateManager rabbit)
    {
        if (rabbit.enemySerch.IsNear() == false && rabbit.audioSource.isPlaying == false)
        {
            rabbit.audioSource.loop = false;
            rabbit.SwithcState(rabbit.rabbitPatruleState);
        }
        else if (rabbit.audioSource.isPlaying == false)
        {
            rabbit.audioSource.Play();
        }


        checkTimer -= Time.deltaTime;

        if (checkTimer <= 0f)
        {
            checkTimer = checkInterval;
            AlertEnemies(rabbit.transform.position, rabbit.rabbitParameter.GetMaxDistanceScream());
        }

        if (Vector3.Distance(rabbit.enemyPatrulsPoint.GetPlayerTransform().position, rabbit.transform.position) < rabbit.rabbitParameter.GetMaxDistanceToShake())
        {
            rabbit.cameraShake.StartShake();
        }
    }

    public override void OnCollisionState(RabbitStateManager rabbit, Collision collision)
    {

    }

    private void AlertEnemies(Vector3 screamPosition, float radius)
    {
        foreach (var wolf in EnemyManager.Instance.GetWolfs())
        {
            if (wolf != null && wolf.gameObject != null)
            {
                if (Vector3.Distance(wolf.transform.position, screamPosition) <= radius)
                {
                    wolf.SwithcMoveToPointState();
                }
            }
        }

        foreach (var cat in EnemyManager.Instance.GetCats())
        {
            if (cat != null && cat.gameObject != null)
            {
                if (Vector3.Distance(cat.transform.position, screamPosition) <= radius)
                {
                    // cat.GoToScream(screamPosition);
                }
            }
        }
    }
}
