using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public void ResumGame()
    {
        FindAnyObjectByType<PauseController>().GetComponent<IPause>().SetPause(false);
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene(1);
    }
}
