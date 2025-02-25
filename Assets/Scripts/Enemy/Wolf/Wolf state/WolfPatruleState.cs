using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfPatruleState : WolfState
{
    private float timeStartMove;

    public override void EnterState(WolfStateManager wolf)
    {
        wolf.enemyPatrulsPoint.SelectPoint();
        wolf.enemyAI.SetCurrentPoint(wolf.enemyPatrulsPoint.GetActivePoint());
        wolf.enemyAI.SetIsStop(false);
        wolf.enemyBeside.enabled = true;
        wolf.enemyVision.enabled = true;
        wolf.enemySerch.enabled = false;
        timeStartMove = 0;
    }

    public override void OnUpdateState(WolfStateManager wolf)
    {
        if (Vector3.Distance(wolf.transform.position, wolf.enemyPatrulsPoint.GetActivePoint().position) <= wolf.enemyAI.GetNavMeshAgent().stoppingDistance)
        {
            WaitToStartMove(wolf);
        }

        if (wolf.enemyBeside.IsNear() || wolf.enemyVision.IsSeePlayer())
        {
            wolf.SwithcState(wolf.wolfMoveToPlayer);
        }
        wolf.enemyAI.SetCurrentPoint(wolf.enemyPatrulsPoint.GetActivePoint());

    }

    public override void OnCollisionState(WolfStateManager wolf, Collision collision)
    {

    }

    private void WaitToStartMove(WolfStateManager wolf)
    {
        if (wolf.wolfParameters.GetMaxTimeWaitPatrol() > timeStartMove)
        {
            timeStartMove += Time.deltaTime;
            wolf.enemyAI.SetIsStop(true);
        }
        else
        {
            timeStartMove = 0;
            wolf.enemyPatrulsPoint.SelectPoint();
            wolf.enemyAI.SetIsStop(false);
            wolf.enemyAI.SetCurrentPoint(wolf.enemyPatrulsPoint.GetActivePoint());
        }
    }
}
