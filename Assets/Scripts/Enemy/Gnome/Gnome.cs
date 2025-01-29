using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gnome : MonoBehaviour
{
    [SerializeField] private Transform target; 
    [SerializeField] private float speed = 5f;

    private void Start()
    {
        target = FindAnyObjectByType<CharacterController>().transform;
    }

    void Update()
    {
        if (target != null)
        {
            transform.LookAt(target);

            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}