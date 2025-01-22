using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IPause
{
    bool IsPause();
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
}
