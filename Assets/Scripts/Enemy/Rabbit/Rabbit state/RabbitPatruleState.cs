using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitPatruleState : RabbitState
{
    private float maxTimeWait = 10;
    private float timeStartMove;

    public override void EnterState(RabbitStateManager rabbit)
    {
        rabbit.GetEnemyPatrulsPoint().SelectPoint();
        rabbit.GetEnemyAI().SetCurrentPoint(rabbit.GetEnemyPatrulsPoint().GetActivePoint());
        rabbit.GetEnemyAI().SetIsStop(false);
        rabbit.GetEnemyBeside().enabled = true;
        rabbit.GetEnemyVision().enabled = true;
        rabbit.GetEnemySerch().enabled = false;
        timeStartMove = 0;
    }

    public override void OnUpdateState(RabbitStateManager rabbit)
    {
        if (Vector3.Distance(rabbit.transform.position, rabbit.GetEnemyPatrulsPoint().GetActivePoint().position) <= rabbit.GetEnemyAI().GetNavMeshAgent().stoppingDistance)
        {
            WaitToStartMove(rabbit);
        }

        if (rabbit.GetEnemyBeside().IsNear() || rabbit.GetEnemyVision().IsSeePlayer())
        {
            rabbit.SwithcState(rabbit.rabbitScreamState);
        }
        rabbit.GetEnemyAI().SetCurrentPoint(rabbit.GetEnemyPatrulsPoint().GetActivePoint());

    }

    public override void OnCollisionState(RabbitStateManager rabbit, Collision collision)
    {

    }

    private void WaitToStartMove(RabbitStateManager rabbit)
    {
        if (maxTimeWait > timeStartMove)
        {
            timeStartMove += Time.deltaTime;
            rabbit.GetEnemyAI().SetIsStop(true);
        }
        else
        {
            timeStartMove = 0;
            rabbit.GetEnemyPatrulsPoint().SelectPoint();
            rabbit.GetEnemyAI().SetIsStop(false);
            rabbit.GetEnemyAI().SetCurrentPoint(rabbit.GetEnemyPatrulsPoint().GetActivePoint());
        }
    }
}
