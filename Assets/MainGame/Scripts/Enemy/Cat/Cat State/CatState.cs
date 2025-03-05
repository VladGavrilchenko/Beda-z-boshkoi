using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CatState
{
    public abstract void EnterState(CatStateManager cat);
    public abstract void OnUpdateState(CatStateManager cat);
    public abstract void OnCollisionState(CatStateManager cat, Collision collision);
}
