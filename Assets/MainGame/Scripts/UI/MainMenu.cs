using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject settingPanel;
    private Setting setting;

    private void Start()
    {
        Cursor.visible=true;
        Cursor.lockState = CursorLockMode.None;
        setting = FindFirstObjectByType<Setting>();
        SetSettingPanel(false);
    }

    public void LoadScene(int gameSceneIndx)
    {
        SceneManager.LoadScene(gameSceneIndx);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void SetSettingPanel(bool isActive)
    {
        settingPanel.SetActive(isActive);
    }
}
