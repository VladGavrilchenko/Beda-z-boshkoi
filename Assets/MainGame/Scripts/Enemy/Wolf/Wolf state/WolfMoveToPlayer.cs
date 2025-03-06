using UnityEngine;

public class WolfMoveToPlayer : WolfState
{
    public override void EnterState(WolfStateManager wolf)
    {
        wolf.enemyBeside.enabled = false;
        wolf.enemyVision.enabled = false;
        wolf.enemySerch.enabled = true;
        wolf.enemyAI.SetIsStop(false);

        wolf.enemyAI.SetStopDistance(wolf.wolfParameters.GetMoveToPlayerStopDistance());
        wolf.enemyAI.StartFollowing(wolf.enemyPatrulsPoint.GetPlayerTransform());
    }

    public override void OnUpdateState(WolfStateManager wolf)
    {
        if (!wolf.enemySerch.IsNear())
        {
            wolf.enemyAI.StopFollowing();
            wolf.SwitchState(wolf.wolfMoveToPointState);
            return;
        }

        if (Vector3.Distance(wolf.transform.position, wolf.enemyPatrulsPoint.GetPlayerTransform().position) < wolf.wolfParameters.GetMoveToPlayerStopDistance())
        {
            wolf.enemyAI.StopFollowing();
            //wolf.SwitchState(wolf.wolfAttackState);
        }
    }

    public override void OnCollisionState(WolfStateManager wolf, Collision collision)
    {
    }
}
