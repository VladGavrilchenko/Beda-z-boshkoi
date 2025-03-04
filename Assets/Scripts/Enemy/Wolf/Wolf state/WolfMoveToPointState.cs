using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WolfMoveToPointState : WolfState
{
    private float timeStartMove;
    private Transform lostTarget;

    public override void EnterState(WolfStateManager wolf)
    {
        wolf.enemyBeside.enabled = true;
        wolf.enemyVision.enabled = true;
        wolf.enemySerch.enabled = false;


        lostTarget = wolf.SpawnMovePoint(wolf.enemyPatrulsPoint.GetPlayerTransform().position);
        timeStartMove = 0;

        wolf.enemyAI.SetIsStop(false);
        wolf.enemyAI.SetStopDistance(wolf.wolfParameters.GetPatruleStopDistance());
        wolf.enemyAI.SetCurrentPoint(lostTarget);
        wolf.enemyAI.Move();
    }

    public override void OnUpdateState(WolfStateManager wolf)
    {
        if (wolf.enemyBeside.IsNear() || wolf.enemyVision.IsSeePlayer())
        {
            wolf.SwitchState(wolf.wolfMoveToPlayer);
        }

        if (Vector3.Distance(wolf.transform.position, lostTarget.position) <= wolf.enemyAI.GetNavMeshAgent().stoppingDistance)
        {
            WaitToStartMove(wolf);
        }

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
            wolf.DestroyTempObject();
            wolf.SwitchState(wolf.wolfPatruleState);
        }
    }
}
