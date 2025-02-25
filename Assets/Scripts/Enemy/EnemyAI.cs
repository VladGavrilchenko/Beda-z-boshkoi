using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent agent;
    private bool isStop;
    private bool isMoveToTransform;
    private Transform currentPoint;
    private Vector3 currentPosition;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        agent.isStopped = isStop;

        if (isMoveToTransform)
        {
            currentPosition = currentPoint.position;
        }

        agent.SetDestination(currentPosition);
    }

    public void SetCurrentPoint(Transform newCurrentPoint)
    {
        currentPoint = newCurrentPoint;
        isMoveToTransform = true;
    }

    public void SetCurrentPoint(Vector3 newCurrentPosition)
    {
        currentPosition = newCurrentPosition;
        isMoveToTransform = false;
    }

    public NavMeshAgent GetNavMeshAgent()
    {
        return agent;
    }

    public void SetSpeed(float speed)
    {
        agent.speed = speed;
    }

    public void SetIsStop(bool isStop)
    {
        this.isStop = isStop;
    }
}
