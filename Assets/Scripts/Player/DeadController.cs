using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadController : MonoBehaviour
{

    [SerializeField] private GameObject deadUI;

    // Start is called before the first frame update
    void Start()
    {
        deadUI.gameObject.SetActive(false);
    }

    public void SetDead()
    {
        deadUI.SetActive(true);
    }
}
