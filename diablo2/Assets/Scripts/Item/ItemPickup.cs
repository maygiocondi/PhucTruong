using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;

    private void Start()
    {
        radius = 3f;
    }

    private void Update()
    {
        if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance <= radius)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }

    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    public void PickUp()
    {

        Debug.Log("Picking up " + item.name);
        bool wasPickup = Inventory.ins.Add(item);
        if (wasPickup)
        {
            Destroy(gameObject);
        }
    }
}


