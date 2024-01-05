
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{

    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;


    public int armorModifier;
    public int damageModifier;
    public int healModifier;
    public int price;
    public string skill;

    // Called when the item is pressed in the inventory
    public virtual void Use()
    {
        // Use the item
        // Something might happen

        Debug.Log("Using " + name);
    }

    public void RemoveFromInventory()
    {
        Inventory.ins.Remove(this);
    }

}
