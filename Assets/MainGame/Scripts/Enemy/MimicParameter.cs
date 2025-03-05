using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimicParameter : MonoBehaviour
{
    [SerializeField] protected float minTimeWaitPatrol = 3;
    [SerializeField] protected float maxTimeWaitPatrol = 10;
    protected float timeWaitPatrol;

    [SerializeField] protected float minTimeWaitToLostPoint = 3;
    [SerializeField] protected float maxTimeWaitToLostPoint = 10;
    protected float timeWaitToLostPoint;

    [SerializeField] protected float minPatruleStopDistance = 3;
    [SerializeField] protected float maxPatruleStopDistance = 10;
    protected float patruleStopDistance;

    [SerializeField] protected float patruleSpeed = 5;
    [SerializeField] protected float attackSpeed = 10;


    private void Awake()
    {
        RandomPatruleStopDistance();
        RandomTimeWaitPatrol();
        timeWaitToLostPoint = Random.Range(minTimeWaitToLostPoint, maxTimeWaitToLostPoint);
    }

    public void RandomPatruleStopDistance()
    {
        patruleStopDistance = Random.Range(minPatruleStopDistance, maxPatruleStopDistance);
    }

    public void RandomTimeWaitPatrol()
    {
        timeWaitPatrol = Random.Range(minTimeWaitPatrol, maxTimeWaitPatrol);
    }

    public float GetTimeWaitPatrol()
    {
        return timeWaitPatrol;
    }

    public float GetPatruleStopDistance()
    {
        return patruleStopDistance;
    }

    public float GetTimeWaitToLostPoint()
    {
        return timeWaitToLostPoint;
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
