using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyPatrulsPoint : MonoBehaviour
{
    private List<Transform> patrolPoints = new List<Transform>();
    private List<Transform> passedPoints = new List<Transform>();
    private Transform activePoint;
    private int randomSport;
    private Transform playerTransform;

    private void Awake()
    {
        playerTransform = FindObjectOfType<CharacterController>().transform;
    }

    public void SetPatrolPoints(Transform[] points)
    {
        patrolPoints = points.ToList();
    }

    public Transform GetPlayerTransform()
    {
        return playerTransform;
    }

    public void SelectPoint()
    {
        if (patrolPoints.Count == 0)
        {
            UpdatePoints();
        }

        randomSport = Random.Range(0, patrolPoints.Count);
        activePoint = patrolPoints[randomSport];
        passedPoints.Add(activePoint);
        patrolPoints.Remove(activePoint);
    }

    private void UpdatePoints()
    {
        foreach (Transform points in passedPoints)
        {
            patrolPoints.Add(points);
        }
        passedPoints.Clear();
    }

    public Transform GetActivePoint()
    {
        return activePoint;
    }

    public void SetActivePoint(Transform newActivePoint)
    {
        activePoint = newActivePoint;
    }
}
