using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldCamera: MonoBehaviour
{
    [SerializeField] private GameObject cameraUI;
    [SerializeField] private GameObject cameraMesh;
    [SerializeField] private int countPhoto;

    private void OnEnable()
    {
        cameraUI.SetActive(true);
        cameraMesh.SetActive(true);
    }

    // Start is called before the first frame update
    private void Awake()
    {
        cameraUI.SetActive(false);
        cameraMesh.SetActive(false);
        enabled = false;
    }
}
