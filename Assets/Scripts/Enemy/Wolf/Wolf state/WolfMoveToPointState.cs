using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WolfMoveToPointState : WolfState
{
    private float maxTimeWait = 10;
    private float timeStartMove;
    private Vector3 position;

    public override void EnterState(WolfStateManager wolf)
    {
        wolf.GetEnemyBeside().enabled = true;
        wolf.GetEnemyVision().enabled = true;
        wolf.GetEnemySerch().enabled = false;
        wolf.GetEnemyAI().SetIsStop(false);
        position = (wolf.GetEnemyPatrulsPoint().GetPlayerTransform().position);
        timeStartMove = 0;
    }

    public override void OnUpdateState(WolfStateManager wolf)
    {
        if (wolf.GetEnemyBeside().IsNear() || wolf.GetEnemyVision().IsSeePlayer())
        {
            wolf.SwithcState(wolf.wolfMoveToPlayer);
        }

        if (Vector3.Distance(wolf.transform.position, position) <= wolf.GetEnemyAI().GetNavMeshAgent().stoppingDistance)
        {
            WaitToStartMove(wolf);
        }

        wolf.GetEnemyAI().SetCurrentPoint(position);
    }

    public override void OnCollisionState(WolfStateManager wolf, Collision collision)
    {

    }

    private void WaitToStartMove(WolfStateManager wolf)
    {
        if (maxTimeWait > timeStartMove)
        {
            timeStartMove += Time.deltaTime;
            wolf.GetEnemyAI().SetIsStop(true);
        }
        else
        {
            timeStartMove = 0;
            wolf.SwithcState(wolf.wolfPatruleState);
        }
    }
}
