using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitStateManager : MonoBehaviour
{
    public RabbitScreamState rabbitScreamState = new RabbitScreamState();
    public RabbitPatruleState rabbitPatruleState = new RabbitPatruleState();
    private RabbitState currentState;
    
    public RabbitParameter rabbitParameter { get; private set; }
    public EnemyVision enemyVision { get; private set; }
    public EnemyBeside enemyBeside { get; private set; }
    public EnemyAI enemyAI { get; private set; }
    public EnemyPatrulsPoint enemyPatrulsPoint { get; private set; }
    public EnemySerch enemySerch { get; private set; }
    public  AudioSource audioSource { get; private set; }
    public CameraShake cameraShake { get; private set; }

    private void Start()
    {
        EnemyManager.Instance.AddToRabbits(this);
        enemyVision = GetComponentInChildren<EnemyVision>();
        enemyBeside = GetComponent<EnemyBeside>();
        enemyAI = GetComponent<EnemyAI>();
        enemyPatrulsPoint = GetComponent<EnemyPatrulsPoint>();
        enemySerch = GetComponent<EnemySerch>();
        audioSource = GetComponentInChildren<AudioSource>();
        cameraShake = FindAnyObjectByType<CameraShake>();
        rabbitParameter = GetComponent<RabbitParameter>();

        enemyAI.SetSpeed(rabbitParameter.GetPatruleSpeed());
        SwitchState(rabbitPatruleState);
    }

    private void Update()
    {
        currentState.OnUpdateState(this);
    }

    public void SwitchState(RabbitState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

    private void OnDestroy()
    {
        EnemyManager.Instance.RemoveRabbit(this);
    }
}
