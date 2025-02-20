using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfPatruleState : WolfState
{
    private float maxTimeWait = 10;
    private float timeStartMove;

    public override void EnterState(WolfStateManager wolf)
    {
        wolf.GetEnemyPatrulsPoint().SelectPoint();
        wolf.GetEnemyAI().SetCurrentPoint(wolf.GetEnemyPatrulsPoint().GetActivePoint());
        wolf.GetEnemyAI().SetIsStop(false);
        wolf.GetEnemyBeside().enabled = true;
        wolf.GetEnemyVision().enabled = true;
        wolf.GetEnemySerch().enabled = false;
        timeStartMove = 0;
    }

    public override void OnUpdateState(WolfStateManager wolf)
    {
        if (Vector3.Distance(wolf.transform.position, wolf.GetEnemyPatrulsPoint().GetActivePoint().position) <= wolf.GetEnemyAI().GetNavMeshAgent().stoppingDistance)
        {
            WaitToStartMove(wolf);
        }

        if (wolf.GetEnemyBeside().IsNear() || wolf.GetEnemyVision().IsSeePlayer())
        {
            wolf.SwithcState(wolf.wolfMoveToPlayer);
        }
        wolf.GetEnemyAI().SetCurrentPoint(wolf.GetEnemyPatrulsPoint().GetActivePoint());

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
            wolf.GetEnemyPatrulsPoint().SelectPoint();
            wolf.GetEnemyAI().SetIsStop(false);
            wolf.GetEnemyAI().SetCurrentPoint(wolf.GetEnemyPatrulsPoint().GetActivePoint());
        }
    }
}
