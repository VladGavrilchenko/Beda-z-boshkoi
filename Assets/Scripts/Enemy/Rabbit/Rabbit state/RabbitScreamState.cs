using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitScreamState : RabbitState
{
    public override void EnterState(RabbitStateManager rabbit)
    {
        rabbit.GetEnemyAI().SetIsStop(true);
        rabbit.GetEnemyBeside().enabled = false;
        rabbit.GetEnemyVision().enabled = false;
        rabbit.GetEnemySerch().enabled = true;
    }

    public override void OnUpdateState(RabbitStateManager rabbit)
    {
        if (rabbit.GetEnemySerch().IsNear() == false)
        {
            rabbit.SwithcState(rabbit.rabbitPatruleState);
        }
    }

    public override void OnCollisionState(RabbitStateManager rabbit, Collision collision)
    {

    }
}
