using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatPatruleState : CatState
{
    private float maxTimeWait = 10;
    private float timeStartMove;

    public override void EnterState(CatStateManager cat)
    {
        cat.enemyPatrulsPoint.SelectPoint();
        cat.enemyAI.SetCurrentPoint(cat.enemyPatrulsPoint.GetActivePoint());
        cat.enemyAI.SetIsStop(false);
        cat.enemyBeside.enabled = true;
        cat.enemyVision.enabled = true;
        cat.enemySerch.enabled = false;
        timeStartMove = 0;
    }

    public override void OnUpdateState(CatStateManager cat)
    {
        if (Vector3.Distance(cat.transform.position, cat.enemyPatrulsPoint.GetActivePoint().position) <= cat.enemyAI.GetNavMeshAgent().stoppingDistance)
        {
            WaitToStartMove(cat);
        }

        if (cat.enemyBeside.IsNear() || cat.enemyVision.IsSeePlayer())
        {
            //cat.SwithcState(cat.wolfMoveToPlayer);
        }
        cat.enemyAI.SetCurrentPoint(cat.enemyPatrulsPoint.GetActivePoint());

    }

    public override void OnCollisionState(CatStateManager cat, Collision collision)
    {

    }

    private void WaitToStartMove(CatStateManager cat)
    {
        if (maxTimeWait > timeStartMove)
        {
            timeStartMove += Time.deltaTime;
            cat.enemyAI.SetIsStop(true);
        }
        else
        {
            timeStartMove = 0;
            cat.enemyPatrulsPoint.SelectPoint();
            cat.enemyAI.SetIsStop(false);
            cat.enemyAI.SetCurrentPoint(cat.enemyPatrulsPoint.GetActivePoint());
        }
    }
}
