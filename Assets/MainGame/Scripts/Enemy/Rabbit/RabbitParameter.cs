using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitParameter : MimicParameter
{
    [SerializeField] private float maxDistanceToShake;
    [SerializeField] private float maxDistanceScream;
    public float GetMaxDistanceToShake()
    {
        return maxDistanceToShake;
    }

    public float GetMaxDistanceScream()
    {
        return maxDistanceScream;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, maxDistanceToShake);
    }
}
