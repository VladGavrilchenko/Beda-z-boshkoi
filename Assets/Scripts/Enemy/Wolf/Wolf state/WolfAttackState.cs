using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAttackState : WolfState
{
    public override void EnterState(WolfStateManager wolf)
    {
        wolf.enemyAI.SetIsStop(false);
        wolf.enemyAI.SetCurrentPoint(wolf.enemyPatrulsPoint.GetPlayerTransform());
        wolf.enemyAI.GetNavMeshAgent().stoppingDistance = 0;
        wolf.enemyAI.SetSpeed(wolf.wolfParameters.GetAttackSpeed());
    }

    public override void OnUpdateState(WolfStateManager wolf)
    {

    }

    public override void OnCollisionState(WolfStateManager wolf, Collision collision)
    {

    }
}
