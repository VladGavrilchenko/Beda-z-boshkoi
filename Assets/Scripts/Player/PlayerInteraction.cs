using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float tekeDistans;
    [SerializeField] private GameObject interactiveTextUI;
    Interactive currentInteractive;
    private bool canInteraction;

    private void Awake()
    {
        canInteraction = true;
    }

    private void Update()
    {
        CheckInteraction();

        if (canInteraction == false)
        {
            if (interactiveTextUI.activeSelf)
            {
                interactiveTextUI.SetActive(false);
            }
            return;
        }


        if (Input.GetKeyDown(KeyCode.E))
        {
            Interaction();
        }
    }

    public void SetCanInteraction(bool canInteraction)
    {
        this.canInteraction = canInteraction;
    }

    private void CheckInteraction()
    {
        RaycastHit hit;
        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, tekeDistans);
        if (hit.collider != null)
        {
            if (hit.transform.GetComponent<Interactive>() != null)
            {
                currentInteractive = hit.transform.GetComponent<Interactive>();
                if (interactiveTextUI.activeSelf == false && canInteraction)
                {
                    interactiveTextUI.SetActive(true);
                }
                return;
            }
        }

        if (interactiveTextUI.activeSelf)
        {
            interactiveTextUI.SetActive(false);
        }

        currentInteractive = null;

    }

    private void Interaction()
    {
        if (currentInteractive != null)
        {
            currentInteractive.Interact();
        }
    }
}
