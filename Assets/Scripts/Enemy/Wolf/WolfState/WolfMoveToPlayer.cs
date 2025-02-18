using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfMoveToPlayer : WolfState
{
    public override void EnterState(WolfStateManager wolf)
    {
        wolf.GetEnemyAI().SetIsStop(false);
        wolf.GetEnemyAI().SetCurrentPoint(wolf.GetEnemyPatrulsPoint().GetPlayerTransform());
        wolf.GetEnemyBeside().enabled = false;
        wolf.GetEnemyVision().enabled = false;
    }

    public override void OnUpdateState(WolfStateManager wolf)
    {
  
    }

    public override void OnCollisionState(WolfStateManager wolf, Collision collision)
    {

    }
}
