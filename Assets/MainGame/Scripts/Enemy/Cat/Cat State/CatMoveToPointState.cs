using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMoveToPointState : CatState
{
    private Vector3 position;

    public override void EnterState(CatStateManager cat)
    {
        cat.enemyBeside.enabled = true;
        cat.enemyVision.enabled = true;
        cat.enemySerch.enabled = false;
        cat.enemyAI.SetIsStop(false);
        cat.enemyAI.SetStopDistance(cat.catParameters.GetPatruleStopDistance());
        position = cat.enemyPatrulsPoint.GetPlayerTransform().position;
    }

    public override void OnUpdateState(CatStateManager cat)
    {
        if (cat.enemyBeside.IsNear() || cat.enemyVision.IsSeePlayer())
        {
            cat.SwitchState(cat.catMoveToPlayer);
        }

        if (Vector3.Distance(cat.transform.position, position) <= cat.enemyAI.GetNavMeshAgent().stoppingDistance)
        {
            StartStay(cat);
        }

       // cat.enemyAI.SetCurrentPoint(position);
    }

    public override void OnCollisionState(CatStateManager cat, Collision collision)
    {

    }


    private void StartStay(CatStateManager cat)
    {
        cat.SwitchState(cat.catStayState);
    }
}
