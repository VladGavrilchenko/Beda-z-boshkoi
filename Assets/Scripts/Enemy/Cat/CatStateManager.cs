using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatStateManager : MonoBehaviour
{
    public CatMoveToPlayer catMoveToPlayer = new CatMoveToPlayer();
    public CatMoveToPointState catMoveToPointState = new CatMoveToPointState();
    public CatAttackState catAttackState = new CatAttackState();
    public CatPatruleState catPatruleState = new CatPatruleState();
    private CatState currentState;

    public EnemyVision enemyVision { get; private set; }
    public EnemyBeside enemyBeside { get; private set; }
    public EnemyAI enemyAI { get; private set; }
    public EnemyPatrulsPoint enemyPatrulsPoint { get; private set; }
    public EnemySerch enemySerch { get; private set; }
    private void Start()
    {
        enemyVision = GetComponentInChildren<EnemyVision>();
        enemyBeside = GetComponent<EnemyBeside>();
        enemyAI = GetComponent<EnemyAI>();
        enemyPatrulsPoint = GetComponent<EnemyPatrulsPoint>();
        enemySerch = GetComponent<EnemySerch>();
        currentState = catPatruleState;
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

    public void SwithcState(CatState state)
    {
        currentState = state;
        currentState.EnterState(this);
        Debug.Log(currentState);
    }
}
