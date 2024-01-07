using UnityEngine.UI;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{

    public Image icon;

    public Item item;

    public Button removeButton; // Reference to the remove button

  // Current item in the slot

    // Add item to the slot
    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    // Clear the slot
    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    // Called when the remove button is pressed
    public void OnRemoveButton()
    {
        if (NPC.ins.isSale)
        {
            PlayerStat.ins.gold += item.price;

            if (PlayerStat.ins.onGoldChangedCallback != null)
                PlayerStat.ins.onGoldChangedCallback.Invoke();
        }
        Inventory.ins.Remove(item); 
    }


    // Called when the item is pressed
    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }
}
