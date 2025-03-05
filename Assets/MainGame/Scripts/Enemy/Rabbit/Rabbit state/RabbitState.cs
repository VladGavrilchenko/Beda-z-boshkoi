using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RabbitState
{
    public abstract void EnterState(RabbitStateManager rabbit);
    public abstract void OnUpdateState(RabbitStateManager rabbit);
    public abstract void OnCollisionState(RabbitStateManager rabbit, Collision collision);
}
