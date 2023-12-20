using Unity.VisualScripting;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;

    public Transform interactableTransform;

    private bool isFocus = false;
    private bool hasInteracted = false;
    Transform player;

    public virtual void Interact()
    {
        // This method is meant to be overwritten
        Debug.Log("Interacting with " + transform.name);
    }

    private void Update()
    {
        if(isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if(distance <= radius)
            {
                Interact();
                hasInteracted = true;
            }
        }
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
        if(interactableTransform == null)
            interactableTransform= transform;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
