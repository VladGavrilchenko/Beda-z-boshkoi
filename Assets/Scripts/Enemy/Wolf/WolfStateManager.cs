using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfStateManager : MonoBehaviour
{
    public WolfMoveToPlayer wolfMoveToPlayer = new WolfMoveToPlayer();
    public WolfAttackState wolfAttackState= new WolfAttackState();
    public WolfPatruleState wolfPatruleState = new WolfPatruleState();
    public WolfMoveToPointState wolfMoveToPointState = new WolfMoveToPointState();
    private WolfState currentState;

    public EnemyVision enemyVision { get; private set; }
    public EnemyBeside enemyBeside { get; private set; }
    public EnemyAI enemyAI { get; private set; }
    public EnemyPatrulsPoint enemyPatrulsPoint { get; private set; }
    public EnemySerch enemySerch { get; private set; }
    public WolfParameters wolfParameters { get; private set; }

    private void Start()
    {
        EnemyManager.Instance.AddToWolfs(this);
        enemyVision = GetComponentInChildren<EnemyVision>();
        enemyBeside = GetComponent<EnemyBeside>();
        enemyAI = GetComponent<EnemyAI>();
        enemyPatrulsPoint = GetComponent<EnemyPatrulsPoint>();
        enemySerch = GetComponent<EnemySerch>();
        wolfParameters = GetComponent<WolfParameters>();
        
        enemyAI.SetSpeed(wolfParameters.GetPatruleSpeed());

        SwitchState(wolfPatruleState);
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

    public void SwitchState(WolfState state)
    {
        currentState = state;
        currentState.EnterState(this);
        Debug.Log(currentState);
    }

    public void SwithcMoveToPointState()
    {
        if(currentState != wolfMoveToPlayer || currentState != wolfAttackState)
        {
            SwitchState(wolfMoveToPointState);
        }
    }

    private void OnDestroy()
    {
        EnemyManager.Instance.RemoveWolf(this);
    }
}
