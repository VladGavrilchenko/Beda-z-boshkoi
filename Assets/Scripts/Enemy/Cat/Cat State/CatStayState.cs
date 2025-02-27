using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatStayState : CatState
{
    private float timeStartMove;

    public override void EnterState(CatStateManager cat)
    {
        cat.enemyAI.SetIsStop(true);
        cat.enemyBeside.enabled = true;
        cat.enemyVision.enabled = true;
        cat.enemySerch.enabled = false;
        timeStartMove = 0;
        cat.SetMimick(true);
    }


    public override void OnUpdateState(CatStateManager cat)
    {
        if (cat.enemyBeside.IsNear() || cat.enemyVision.IsSeePlayer())
        {
            cat.SetMimick(false);
            cat.SwitchState(cat.catMoveToPlayer);
        }
        else
        {
            WaitToStartMove(cat);
        }
    }


    public override void OnCollisionState(CatStateManager cat, Collision collision)
    {

    }

    private void WaitToStartMove(CatStateManager cat)
    {
        if (cat.catParameters.GetMaxStayTime() > timeStartMove)
        {
            timeStartMove += Time.deltaTime;
            cat.enemyAI.SetIsStop(true);
        }
        else
        {
            cat.SwitchState(cat.catPatruleState);
        }
    }
}
