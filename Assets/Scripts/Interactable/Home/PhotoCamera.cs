using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PhotoCamera: MonoBehaviour
{
    [SerializeField] private GameObject cameraUI;
    [SerializeField] private GameObject cameraMesh;
    [SerializeField] private int countPhoto;
    [SerializeField] TMP_Text countText;


    // Start is called before the first frame update
    private void Awake()
    {
        cameraUI.SetActive(false);
        cameraMesh.SetActive(false);
        enabled = false;
        UpdateUI();
        SetActive(false);
    }

    public void AddCountPhoto(int addCountPhoto)
    {
        countPhoto += addCountPhoto;
        UpdateUI();
    }

    private void UpdateUI()
    {
        countText.text = countPhoto.ToString();
    }

    public void SetActive(bool isActive)
    {
        cameraUI.SetActive(isActive);
        cameraMesh.SetActive(isActive);
    }
}
