using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimickActivator : MonoBehaviour
{
    [SerializeField] protected ParticleSystem spawnParticle;
    [SerializeField] protected float minRangeToSearch;
    [SerializeField] protected LayerMask obstacleLayers;
    [SerializeField] protected GameObject spawnMonster;
    [SerializeField] protected float spawnDelay = 2f;
    protected Transform playerTransform;
    protected float distanceToPlayer;
    protected bool isStartSpawn;


    private void Update()
    {
        if (isStartSpawn)
        {
            return;
        }

        distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer <= minRangeToSearch)
        {
            if (CanSeePlayer())
            {
                isStartSpawn = true;
                StartCoroutine(SpawnMonsterWithDelay());
            }
        }
    }

    protected bool CanSeePlayer()
    {
        Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, playerTransform.position);

        Debug.DrawRay(transform.position, directionToPlayer * distance, Color.red, 0.1f); 

        if (Physics.Raycast(transform.position, directionToPlayer, out RaycastHit hit, distance, obstacleLayers))
        {
            if (((1 << hit.collider.gameObject.layer) & obstacleLayers) != 0)
            {
                return false;
            }
        }

        return true;
    }


    public void SetActive(bool isActive)
    {
        if (isActive)
        {
            playerTransform = FindAnyObjectByType<PlayerMover>().transform;
        }
        else
        {
            Destroy(this);
        }
    }

    protected IEnumerator SpawnMonsterWithDelay()
    {
        GameObject temp = Instantiate(spawnParticle, transform.position , Quaternion.identity).gameObject;
        temp.transform.SetParent(transform.GetChild(0));
        yield return new WaitForSeconds(spawnDelay);
        Destroy(temp);
        Destroy(gameObject);
        Instantiate(spawnMonster, transform.position, Quaternion.identity);
    }
}