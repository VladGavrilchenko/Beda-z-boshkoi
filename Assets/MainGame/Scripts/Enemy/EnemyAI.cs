using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float recalcInterval = 0.5f;
    private Vector3 movePos;
    private NavMeshAgent agent;
    private Transform target;
    private bool isFollowing;
    private float recalcTimer;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            Debug.LogError("NavMeshAgent компонент відсутній!");
        }
    }

    void Update()
    {
        if (isFollowing && agent.enabled && target != null)
        {
            if (!agent.isOnNavMesh)
            {
                return;
            }

            recalcTimer -= Time.deltaTime;
            if (recalcTimer <= 0f)
            {
                movePos = target.position;
                agent.SetDestination(movePos);
                recalcTimer = recalcInterval;
            }
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
        target = playerTransform;
        isFollowing = true;
        recalcTimer = 0f;
    }

    public void StopFollowing()
    {
        isFollowing = false;
        agent.ResetPath();
    }

    public void Move()
    {
        if (agent.enabled && agent.isOnNavMesh && target != null)
        {
            agent.SetDestination(target.position);
        }
    }
}
