using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent agent;
    private bool isStop;
    private Transform currentPoint;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        agent.isStopped = isStop;
        agent.SetDestination(currentPoint.position);
    }

    public void SetCurrentPoint(Transform newCurrentPoint)
    {
        currentPoint = newCurrentPoint;
    }

    public NavMeshAgent GetNavMeshAgent()
    {
        return agent;
    }

    public void SetIsStop(bool isStop)
    {
        this.isStop = isStop;
    }
}
