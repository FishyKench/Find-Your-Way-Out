using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Vector3 interactionRayPoint = default;
    [SerializeField] private float interactionDistance = default;
    [SerializeField] private LayerMask interactionLayer = default;
    [SerializeField] private bool canInteract = true;
    [SerializeField] private KeyCode interactKey = KeyCode.E;

    [Header("UI")]
    public GameObject crosshair;

    private interactable currentInteractable;

    [SerializeField] private Camera cam;

    private void Update()
    {
        if (canInteract)
        {
            HandleInteractionCheck();
            HandleInteractionInput();
        }

    }

    private void HandleInteractionCheck()
    {
        if(Physics.Raycast(cam.ViewportPointToRay(interactionRayPoint), out RaycastHit hit, interactionDistance, LayerMask.GetMask("interactable")))
        {
            if(hit.collider.gameObject.layer == 11 && (currentInteractable == null || hit.collider.gameObject.GetInstanceID() != currentInteractable.gameObject.GetInstanceID()))
            {
                hit.collider.TryGetComponent(out currentInteractable);

                if (currentInteractable)
                {
                    currentInteractable.OnFocus();
                    crosshair.transform.localScale = new Vector3(.1f, .1f, .1f);
                }
            }
        }
        else if (currentInteractable)
        {
            currentInteractable.OnLoseFocus();
            currentInteractable = null;
            crosshair.transform.localScale = new Vector3(.05f, .05f, .05f);
        }
    }
    private void HandleInteractionInput()
    {
        if(Input.GetKeyDown(interactKey) && currentInteractable != null && Physics.Raycast(cam.ViewportPointToRay(interactionRayPoint), out RaycastHit hit, interactionDistance, interactionLayer))
        {
            currentInteractable.OnInteract();
        }
    }
}
