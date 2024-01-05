using Unity.VisualScripting;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Transform interactableTransform;

    public float radius;

    protected bool isFocus = false;
    protected bool hasInteracted = false;
    protected Transform player;

    public virtual void Interact()
    {
        // This method is meant to be overwritten
    }

    public void OnFocused(Transform playerTranform)
    {
        isFocus = true;
        player = playerTranform;
        hasInteracted = false;
    }

    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    void OnDrawGizmosSelected()
    {
        if (interactableTransform == null)
            interactableTransform = transform;

        Gizmos.color = Color.yellow;
       // Gizmos.DrawWireSphere(transform.position);
    }
}

