using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatParameters : MimicParameter
{
    [SerializeField] private float maxStayTime;
    [SerializeField] private float moveToPlayerStopDistance;
    [SerializeField] private float patruleStopDistance;

    public float GetMoveToPlayerStopDistance()
    {
        return moveToPlayerStopDistance;
    }

    public float GetMaxStayTime()
    {
        return maxStayTime;
    }

    public float GetPatruleStopDistance()
    {
        return patruleStopDistance;
    }
}
