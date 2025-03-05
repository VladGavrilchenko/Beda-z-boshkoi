using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMoveToPlayer : CatState
{
    public override void EnterState(CatStateManager cat)
    {
        cat.enemyAI.SetStopDistance(cat.catParameters.GetMoveToPlayerStopDistance());
        cat.enemyBeside.enabled = false;
        cat.enemyVision.enabled = false;
        cat.enemySerch.enabled = true;
        cat.enemyAI.SetCurrentPoint(cat.enemyPatrulsPoint.GetPlayerTransform());
        cat.enemyAI.SetIsStop(false);
    }

    public override void OnUpdateState(CatStateManager cat)
    {
        if (cat.enemySerch.IsNear() == false)
        {
            cat.SwitchState(cat.catMoveToPointState);
        }

        if (Vector3.Distance(cat.transform.position, cat.enemyPatrulsPoint.GetPlayerTransform().position) < 2)
        {
            cat.SwitchState(cat.catAttackState);
        }

        cat.enemyAI.SetIsStop(false);
        cat.enemyAI.SetCurrentPoint(cat.enemyPatrulsPoint.GetPlayerTransform());
    }
    public override void OnCollisionState(CatStateManager cat, Collision collision)
    {

    }
}
