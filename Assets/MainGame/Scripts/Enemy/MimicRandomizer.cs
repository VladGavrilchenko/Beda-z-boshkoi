using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MimicRandomizer : MonoBehaviour
{
    [SerializeField] private List<MimickActivator> mimickActivators;
    [SerializeField] private int countActive;
    [SerializeField] private bool isActiveOnStart;

    private void Start()
    {
        if (isActiveOnStart == false)
        {
            return;
        }

        foreach (var activator in mimickActivators)
        {
            activator.enabled = false;
        }

        ActiveMimick();
    }

    public  void DisableMimick()
    {
        foreach (var activator in mimickActivators)
        {
            activator.enabled =false;
        }
    }

    public void ActiveMimick()
    {
        int randomIndx;

        for (int i = 0; i < countActive; i++)
        {
            if (mimickActivators.Count == 0)
            {
                return;
            }

            randomIndx = Random.Range(0, mimickActivators.Count);
            mimickActivators[randomIndx].enabled = true;
            mimickActivators.RemoveAt(randomIndx);
        }

        if (mimickActivators.Count == 0)
        {
            return;
        }

        foreach (var activator in mimickActivators)
        {
            activator.SetActive(false);
        }
        Destroy(this);
    }
}
