using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class WolfMoveToPlayer : WolfState
{
    public override void EnterState(WolfStateManager wolf)
    {
        wolf.GetEnemyAI().SetIsStop(false);
        wolf.GetEnemyAI().SetCurrentPoint(wolf.GetEnemyPatrulsPoint().GetPlayerTransform());
        wolf.GetEnemyBeside().enabled = false;
        wolf.GetEnemyVision().enabled = false;
        wolf.GetEnemySerch().enabled = true;
    }

    public override void OnUpdateState(WolfStateManager wolf)
    {
        if (wolf.GetEnemySerch().IsNear())
        {

        }

        if(Vector3.Distance(wolf.transform.position, wolf.GetEnemyPatrulsPoint().GetPlayerTransform().position) < 2)
        {
            wolf.SwithcState(wolf.wolfAttackState);
        }
    }

    public override void OnCollisionState(WolfStateManager wolf, Collision collision)
    {

    }
}
