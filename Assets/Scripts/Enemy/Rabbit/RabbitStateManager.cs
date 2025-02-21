using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitStateManager : MonoBehaviour
{
    public RabbitScreamState rabbitScreamState = new RabbitScreamState();
    public RabbitPatruleState rabbitPatruleState = new RabbitPatruleState();
    private RabbitState currentState;

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
        SwithcState(rabbitPatruleState);
    }

    private void Update()
    {
        currentState.OnUpdateState(this);
    }


    public void SwithcState(RabbitState state)
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
