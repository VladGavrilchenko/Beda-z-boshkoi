using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfParameters : MimicParameter
{
    [SerializeField] private float playerDamage;
    [SerializeField] private float moveToPlayerStopDistance;

    public float TakeDamageAndDead()
    {
        Destroy(gameObject);
        return playerDamage;
    }

    public float GetMoveToPlayerStopDistance()
    {
        return moveToPlayerStopDistance;
    }


}
