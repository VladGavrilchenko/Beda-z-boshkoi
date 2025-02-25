using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimicParameter : MonoBehaviour
{
    [SerializeField] protected float maxTimeWaitPatrol = 10;
    [SerializeField] protected float maxTimeWaitToLostPoint = 10;
    [SerializeField] protected float patruleSpeed = 5;
    [SerializeField] protected float attackSpeed = 10;

    public float GetMaxTimeWaitPatrol()
    {
        return maxTimeWaitPatrol;
    }

    public float GetMaxTimeWaitToLostPoint()
    {
        return maxTimeWaitToLostPoint;
    }

    public float GetAttackSpeed()
    {
        return attackSpeed;
    }

    public float GetPatruleSpeed() 
    { 
        return patruleSpeed;
    }
}
