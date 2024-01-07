using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverInventory : Hover
{
    public InventorySlot inventorySlot;

    private void Start()
    {
        inventorySlot = GetComponent<InventorySlot>();
        hoverUI = HoverUI.ins;
    }

    public override void ShowItemInfo()
    {
        base.ShowItemInfo();
        if (inventorySlot.item != null)
        {
            hoverUI.itemInfo.SetActive(true);
            hoverUI.damageText.text = inventorySlot.item.damageModifier.ToString();
            hoverUI.armorText.text = inventorySlot.item.armorModifier.ToString();
            hoverUI.skillText.text = inventorySlot.item.skill;
            hoverUI.priceText.text = inventorySlot.item.price.ToString();
        }
        else
        { return; }
    }

    public void HideItemInfo()
    {
        hoverUI.itemInfo.SetActive(false);
    }
}
