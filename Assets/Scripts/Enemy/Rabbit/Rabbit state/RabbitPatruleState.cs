using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitPatruleState : RabbitState
{
    private float timeStartMove;

    public override void EnterState(RabbitStateManager rabbit)
    {
        rabbit.enemyPatrulsPoint.SelectPoint();
        rabbit.enemyAI.SetCurrentPoint(rabbit.enemyPatrulsPoint.GetActivePoint());
        rabbit.enemyAI.SetIsStop(false);
        rabbit.enemyBeside.enabled = true;
        rabbit.enemyVision.enabled = true;
        rabbit.enemySerch.enabled = false;
        timeStartMove = 0;
    }

    public override void OnUpdateState(RabbitStateManager rabbit)
    {
        if (Vector3.Distance(rabbit.transform.position, rabbit.enemyPatrulsPoint.GetActivePoint().position) <= rabbit.enemyAI.GetNavMeshAgent().stoppingDistance)
        {
            WaitToStartMove(rabbit);
        }

        if (rabbit.enemyBeside.IsNear() || rabbit.enemyVision.IsSeePlayer())
        {
            rabbit.SwitchState(rabbit.rabbitScreamState);
        }

        rabbit.enemyAI.SetCurrentPoint(rabbit.enemyPatrulsPoint.GetActivePoint());
    }

    public override void OnCollisionState(RabbitStateManager rabbit, Collision collision)
    {

    }

    private void WaitToStartMove(RabbitStateManager rabbit)
    {
        if (rabbit.rabbitParameter.GetMaxTimeWaitPatrol() > timeStartMove)
        {
            timeStartMove += Time.deltaTime;
            rabbit.enemyAI.SetIsStop(true);
        }
        else
        {
            timeStartMove = 0;
            rabbit.enemyPatrulsPoint.SelectPoint();
            rabbit.enemyAI.SetIsStop(false);
            rabbit.enemyAI.SetCurrentPoint(rabbit.enemyPatrulsPoint.GetActivePoint());
        }
    }
}
