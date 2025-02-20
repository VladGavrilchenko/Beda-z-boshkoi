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
    [SerializeField] private Transform shootPoint;
    private Animator animator;
    private bool isCameraInHand = false;

    // Start is called before the first frame update
    private void Awake()
    {
        animator= GetComponentInParent<Animator>();
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

    private void Update()
    {
        bool isHoldingCamera = Input.GetMouseButton(1);

        if (animator.GetCurrentAnimatorStateInfo(0).shortNameHash == Animator.StringToHash("calmingPlayerAnimation"))
        {
            isHoldingCamera = false;
        }


        if (isHoldingCamera != isCameraInHand)
        {
            isCameraInHand = isHoldingCamera;
            animator.SetBool("CameraInHand", isCameraInHand);
        }            
        
        if(Input.GetMouseButtonDown(0) && isHoldingCamera && countPhoto > 0)
        {
           TakePhoto();
        }
    }

    private void TakePhoto()
    {
        countPhoto--;
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
