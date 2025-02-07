using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public void ResumGame()
    {
        FindAnyObjectByType<PauseController>().GetComponent<IPause>().SetPause(false);
    }

    public void ExitToMainMenu()
    {
        Application.Quit();
    }
}
