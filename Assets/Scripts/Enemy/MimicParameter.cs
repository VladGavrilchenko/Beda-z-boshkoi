using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimicParameter : MonoBehaviour
{
    [SerializeField] protected float maxTimeWaitPatrol = 10;
    [SerializeField] protected float maxTimeWaitToLostPoint = 10;

    public float GetMaxTimeWaitPatrol()
    {
        return maxTimeWaitPatrol;
    }

    public float GetMaxTimeWaitToLostPoint()
    {
        return maxTimeWaitToLostPoint;
    }
}
