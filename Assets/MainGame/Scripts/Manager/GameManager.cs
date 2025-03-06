using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private string[] missionsText;
    [SerializeField] private TMP_Text missionText;
    private int currentMission;

    public void SetNextMission(int indxMission)
    {
        missionText.text = missionsText[indxMission];
        currentMission = indxMission;
    }

    public void SetNextMissionText(string text)
    {
        missionText.text = text;
    }

    public int GetCurrentMission() { return currentMission; }
}
