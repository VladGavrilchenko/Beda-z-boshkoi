using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAttackState : WolfState
{
    public override void EnterState(WolfStateManager wolf)
    {
        wolf.GetEnemyAI().SetIsStop(false);
        wolf.GetEnemyAI().SetCurrentPoint(wolf.GetEnemyPatrulsPoint().GetPlayerTransform());
        wolf.GetEnemyAI().GetNavMeshAgent().stoppingDistance = 0;
    }

    public override void OnUpdateState(WolfStateManager wolf)
    {

    }

    public override void OnCollisionState(WolfStateManager wolf, Collision collision)
    {

    }
}
