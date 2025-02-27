using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfMoveToPlayer : WolfState
{
    public override void EnterState(WolfStateManager wolf)
    {
        wolf.enemyAI.SetStopDistance(wolf.wolfParameters.GetMoveToPlayerStopDistance());
        wolf.enemyBeside.enabled = false;
        wolf.enemyVision.enabled = false;
        wolf.enemySerch.enabled = true;
        wolf.enemyAI.SetCurrentPoint(wolf.enemyPatrulsPoint.GetPlayerTransform());
        wolf.enemyAI.SetIsStop(false);
    }

    public override void OnUpdateState(WolfStateManager wolf)
    {
        if (wolf.enemySerch.IsNear() == false)
        {
            wolf.SwitchState(wolf.wolfMoveToPointState);
        }

        if (Vector3.Distance(wolf.transform.position, wolf.enemyPatrulsPoint.GetPlayerTransform().position) < 2)
        {
            wolf.SwitchState(wolf.wolfAttackState);
        }

        wolf.enemyAI.SetIsStop(false);
        wolf.enemyAI.SetCurrentPoint(wolf.enemyPatrulsPoint.GetPlayerTransform());
    }

    public override void OnCollisionState(WolfStateManager wolf, Collision collision)
    {

    }
}
