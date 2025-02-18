using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WolfState
{
    public abstract void EnterState(WolfStateManager wolf);
    public abstract void OnUpdateState(WolfStateManager wolf);
    public abstract void OnCollisionState(WolfStateManager wolf, Collision collision);
}
