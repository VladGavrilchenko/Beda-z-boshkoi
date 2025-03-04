using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform target;
    private bool isFollowing;
    private Coroutine followCoroutine;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void Move()
    {
        if (agent.enabled && agent.isOnNavMesh && target != null)
        {
            agent.SetDestination(target.position);
        }
    }

    public void SetStopDistance(float stoppingDistance)
    {
        agent.stoppingDistance = stoppingDistance;
    }

    public void SetCurrentPoint(Transform newCurrentPoint)
    {
        target = newCurrentPoint;
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
        agent.isStopped = isStop;
    }

    public void StartFollowing(Transform playerTransform)
    {
        if (isFollowing) return; // Запобігає повторному запуску
        target = playerTransform;
        isFollowing = true;
        followCoroutine = StartCoroutine(UpdateDestination());
    }

    public void StopFollowing()
    {
        isFollowing = false;
        if (followCoroutine != null)
        {
            StopCoroutine(followCoroutine);
            followCoroutine = null;
        }
        agent.ResetPath();
    }

    private IEnumerator UpdateDestination()
    {
        while (isFollowing)
        {
            if (target != null && agent.enabled && agent.isOnNavMesh)
            {
                agent.SetDestination(target.position);
            }
            yield return new WaitForSeconds(0.5f); // Рідше оновлюємо ціль
        }
    }
}
