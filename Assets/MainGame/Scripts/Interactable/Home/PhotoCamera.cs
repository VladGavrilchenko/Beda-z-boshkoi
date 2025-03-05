using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class PhotoCamera : MonoBehaviour
{
    [SerializeField] private GameObject cameraUI;
    [SerializeField] private GameObject cameraMesh;
    [SerializeField] private int countPhoto;
    [SerializeField] TMP_Text countText;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float maxPhotoDistance = 10f;
    [SerializeField] private LayerMask enemyLayer; // Шар для ворогів
    [SerializeField] private LayerMask obstacleLayer; // Шар для перешкод
    private Animator animator;
    private bool isCameraInHand = false;
    private Camera mainCamera;

    private void Awake()
    {
        animator = GetComponentInParent<Animator>();
        mainCamera = Camera.main;
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

        if (Input.GetMouseButtonDown(0) && isHoldingCamera && countPhoto > 0)
        {
            if(animator.GetCurrentAnimatorStateInfo(0).shortNameHash == Animator.StringToHash("shotPlayerAnimation") == false)
            {
                TakePhoto();
            }
        }
    }

    private void TakePhoto()
    {
        animator.SetTrigger("Shoot");
        countPhoto--;
        UpdateUI();
        TakeEnemies(shootPoint.position, maxPhotoDistance);
    }

    private void TakeEnemies(Vector3 shootPosition, float maxDistance)
    {
        foreach (var enemy in EnemyManager.Instance.GetRabbits())
        {
            if (enemy != null && enemy.gameObject != null)
            {
                float distance = Vector3.Distance(enemy.transform.position, shootPosition);
                if (distance <= maxDistance && IsVisible(enemy.transform))
                {
                    Destroy(enemy.gameObject);
                }
            }
        }

        foreach (var enemy in EnemyManager.Instance.GetWolfs())
        {
            if (enemy != null && enemy.gameObject != null)
            {
                float distance = Vector3.Distance(enemy.transform.position, shootPosition);
                if (distance <= maxDistance && IsVisible(enemy.transform))
                {
                    Destroy(enemy.gameObject);
                }
            }
        }

        foreach (var enemy in EnemyManager.Instance.GetCats())
        {
            if (enemy != null && enemy.gameObject != null)
            {
                float distance = Vector3.Distance(enemy.transform.position, shootPosition);
                if (distance <= maxDistance && IsVisible(enemy.transform))
                {
                    Destroy(enemy.gameObject);
                }
            }
        }
    }

    private bool IsVisible(Transform enemyTransform)
    {
        Vector3 screenPoint = mainCamera.WorldToViewportPoint(enemyTransform.position);
        if (screenPoint.z < 0 || screenPoint.x < 0 || screenPoint.x > 1 || screenPoint.y < 0 || screenPoint.y > 1)
        {
            return false;
        }

        RaycastHit hit;
        Vector3 direction = (enemyTransform.position - mainCamera.transform.position).normalized;
        float distance = Vector3.Distance(mainCamera.transform.position, enemyTransform.position);

        if (Physics.Raycast(mainCamera.transform.position, direction, out hit, distance, obstacleLayer))
        {
            return false;
        }

        if (Physics.Raycast(mainCamera.transform.position, direction, out hit, distance, enemyLayer))
        {
            return hit.transform == enemyTransform;
        }

        return false;
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