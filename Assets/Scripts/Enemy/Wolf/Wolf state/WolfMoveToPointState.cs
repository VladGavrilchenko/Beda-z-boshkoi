using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WolfMoveToPointState : WolfState
{
    private float timeStartMove;
    private Vector3 position;

    public override void EnterState(WolfStateManager wolf)
    {
        wolf.enemyBeside.enabled = true;
        wolf.enemyVision.enabled = true;
        wolf.enemySerch.enabled = false;
        wolf.enemyAI.SetIsStop(false);
        position = wolf.enemyPatrulsPoint.GetPlayerTransform().position;
        timeStartMove = 0;
    }

    public override void OnUpdateState(WolfStateManager wolf)
    {
        if (wolf.enemyBeside.IsNear() || wolf.enemyVision.IsSeePlayer())
        {
            wolf.SwithcState(wolf.wolfMoveToPlayer);
        }

        if (Vector3.Distance(wolf.transform.position, position) <= wolf.enemyAI.GetNavMeshAgent().stoppingDistance)
        {
            WaitToStartMove(wolf);
        }

        wolf.enemyAI.SetCurrentPoint(position);
    }

    public override void OnCollisionState(WolfStateManager wolf, Collision collision)
    {

    }

    private void WaitToStartMove(WolfStateManager wolf)
    {
        if (wolf.wolfParameters.GetMaxTimeWaitToLostPoint() > timeStartMove)
        {
            timeStartMove += Time.deltaTime;
            wolf.enemyAI.SetIsStop(true);
        }
        else
        {
            timeStartMove = 0;
            wolf.SwithcState(wolf.wolfPatruleState);
        }
    }
}
