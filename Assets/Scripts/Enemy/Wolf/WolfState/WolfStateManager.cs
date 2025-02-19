using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WolfStateManager : MonoBehaviour
{
    public WolfMoveToPlayer wolfMoveToPlayer = new WolfMoveToPlayer();
    public WolfAttackState wolfAttackState= new WolfAttackState();
    public WolfPatruleState wolfPatruleState = new WolfPatruleState();
    private WolfState currentState;

    private EnemyVision enemyVision;
    private EnemyBeside enemyBeside;
    private EnemyAI enemyAI;
    private EnemyPatrulsPoint enemyPatrulsPoint;
    private EnemySerch enemySerch;

    private void Start()
    {
        enemyVision = GetComponentInChildren<EnemyVision>();
        enemyBeside = GetComponent<EnemyBeside>();
        enemyAI = GetComponent<EnemyAI>();
        enemyPatrulsPoint = GetComponent<EnemyPatrulsPoint>();
        enemySerch = GetComponent<EnemySerch>();
        currentState = wolfPatruleState;
        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.OnUpdateState(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionState(this, collision);
    }


    public void SwithcState(WolfState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

    public EnemyPatrulsPoint GetEnemyPatrulsPoint()
    {
        return enemyPatrulsPoint;
    }

    public EnemyAI GetEnemyAI()
    {
        return enemyAI;
    }

    public EnemyBeside GetEnemyBeside()
    {
        return enemyBeside;
    }

    public EnemyVision GetEnemyVision()
    {
        return enemyVision;
    }

    public EnemySerch GetEnemySerch()
    {
        return enemySerch;
    }

}
