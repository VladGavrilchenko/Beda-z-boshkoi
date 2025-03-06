using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CatStateManager : MonoBehaviour
{
    [SerializeField] private GameObject lostPoint;
    private GameObject tempObject;

    [SerializeField] private GameObject mimickObject;
    [SerializeField] private GameObject catObject;

    public CatMoveToPlayer catMoveToPlayer = new CatMoveToPlayer();
    public CatMoveToPointState catMoveToPointState = new CatMoveToPointState();
    public CatAttackState catAttackState = new CatAttackState();
    public CatPatruleState catPatruleState = new CatPatruleState();
    public CatStayState catStayState = new CatStayState();
    private CatState currentState;

    public EnemyVision enemyVision { get; private set; }
    public EnemyBeside enemyBeside { get; private set; }
    public EnemyAI enemyAI { get; private set; }
    public EnemyPatrulsPoint enemyPatrulsPoint { get; private set; }
    public EnemySerch enemySerch { get; private set; }
    public CatParameters catParameters { get; private set; }

    private void Start()
    {
        EnemyManager.Instance.AddToCats(this);
        enemyVision = GetComponentInChildren<EnemyVision>();
        enemyBeside = GetComponent<EnemyBeside>();
        enemyAI = GetComponent<EnemyAI>();
        enemyPatrulsPoint = GetComponent<EnemyPatrulsPoint>();
        enemySerch = GetComponent<EnemySerch>();
        catParameters = GetComponent<CatParameters>();
        SwitchState(catPatruleState);
    }

    private void Update()
    {
        currentState.OnUpdateState(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionState(this, collision);
    }

    public void SwitchState(CatState state)
    {
        currentState = state;
        currentState.EnterState(this);
        Debug.Log(currentState);
    }

    public void SetMimick(bool isMimick)
    {
        mimickObject.SetActive(isMimick);
        catObject.SetActive(!isMimick);
    }

    private void OnDestroy()
    {
        EnemyManager.Instance.RemoveCat(this);
    }

    public Transform SpawnMovePoint(Vector3 lostPointPosition)
    {
        tempObject = Instantiate(lostPoint, lostPointPosition, Quaternion.identity);

        return tempObject.transform;
    }

    public void DestroyTempObject()
    {
        Destroy(tempObject);
    }

}
