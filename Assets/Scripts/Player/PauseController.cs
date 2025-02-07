using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IPause
{
    bool IsPause();
    void SetPause(bool isPause);
}

public class PauseController : MonoBehaviour , IPause
{
    [SerializeField] private GameObject pauseUI;
    private IIsDead iIsDead;
    [SerializeField] private bool isPause;

    public bool IsPause()
    {
        return isPause;
    }

    public void SetPause(bool isPause)
    {
        this.isPause = isPause;
        Pause();
    }

    private void Start()
    {
        iIsDead = FindAnyObjectByType<PlayerMover>().GetComponent<IIsDead>();
        pauseUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && iIsDead.IsDead() == false)
        {
            Pause();
        }
    }
    
    private void Pause()
    {
        pauseUI.SetActive(!pauseUI.activeSelf);
        isPause = pauseUI.activeSelf;

        if (isPause == false)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
}
