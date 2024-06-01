using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactionRange;
    [SerializeField] private LayerMask interactionMask;

    private IInteractable currentInteractable;

    private void Update()
    {
        if(InputManager2.Movement != Vector2.zero)
            interactionPoint.localPosition = new Vector3(InputManager2.Movement.x, InputManager2.Movement.y, 0f).normalized;

        if (!InputManager2.Instance.Interact)
            return;

        CheckForInteractions();

    }

    private void CheckForInteractions()
    {
        Collider2D collider2Ds = Physics2D.OverlapCircle(interactionPoint.position, interactionRange, interactionMask);

        if (collider2Ds == null)
            return;

        currentInteractable = collider2Ds.GetComponent<IInteractable>();
        currentInteractable?.Interact(1); // coins value

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionPoint.position, interactionRange);
    }

}
