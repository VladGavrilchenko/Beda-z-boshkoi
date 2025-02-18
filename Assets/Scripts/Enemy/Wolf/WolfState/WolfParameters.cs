using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfParameters : MonoBehaviour
{
    [SerializeField] private float playerDamage;

    public float TakeDamageAndDead()
    {
        Destroy(gameObject);
        return playerDamage;
    }
}
