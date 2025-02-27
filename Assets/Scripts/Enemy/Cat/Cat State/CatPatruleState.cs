using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatPatruleState : CatState
{
    public override void EnterState(CatStateManager cat)
    {
        cat.enemyPatrulsPoint.SelectPoint();
        cat.enemyAI.SetCurrentPoint(cat.enemyPatrulsPoint.GetActivePoint());
        cat.enemyAI.SetIsStop(false);
        cat.enemyBeside.enabled = true;
        cat.enemyVision.enabled = true;
        cat.enemySerch.enabled = false;
        cat.SetMimick(false);
    }

    public override void OnUpdateState(CatStateManager cat)
    {
        if (Vector3.Distance(cat.transform.position, cat.enemyPatrulsPoint.GetActivePoint().position) <= cat.enemyAI.GetNavMeshAgent().stoppingDistance)
        {
            StartStay(cat);
        }

        if (cat.enemyBeside.IsNear() || cat.enemyVision.IsSeePlayer())
        {
            cat.SwitchState(cat.catMoveToPlayer);
        }
        cat.enemyAI.SetCurrentPoint(cat.enemyPatrulsPoint.GetActivePoint());
    }

    public override void OnCollisionState(CatStateManager cat, Collision collision)
    {

    }

    private void StartStay(CatStateManager cat) 
    {
        cat.SwitchState(cat.catStayState);
    }
}
