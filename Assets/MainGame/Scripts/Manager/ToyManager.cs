using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ToyManager : MonoBehaviour
{
    [SerializeField] private GameObject home;
    [SerializeField] private GameObject grave;

    [SerializeField] private int maxCountToy;
    private int currentCountToy;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    public void AddToCount()
    {
        currentCountToy++;
        gameManager.SetNextMissionText("Toys " + currentCountToy + "/" + maxCountToy);

        if (currentCountToy >= maxCountToy)
        {
            gameManager.SetNextMission(6);

            home.GetComponent<NavMeshObstacle>().enabled = false;
            home.SetActive(false);
            grave.SetActive(true);
        }
    }

    public void StartFinding()
    {
        gameManager.SetNextMissionText("Toy " + currentCountToy + "/" + maxCountToy);
    }
}
