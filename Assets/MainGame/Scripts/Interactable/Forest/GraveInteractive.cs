using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GraveInteractive : Interactive
{
    public override void Interact()
    {
        SceneManager.LoadScene(1);
    }
}
