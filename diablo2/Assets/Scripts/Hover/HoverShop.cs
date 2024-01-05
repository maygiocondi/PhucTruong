using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverShop : Hover
{
    public ShopSlot shopSlot;

    private void Start()
    {
        shopSlot = GetComponent<ShopSlot>();
        hoverUI = HoverUI.ins;
    }

    public override void ShowItemInfo()
    {
        base.ShowItemInfo();
        hoverUI.itemInfo.SetActive(true);
        hoverUI.damageText.text = shopSlot.item.damageModifier.ToString();
        hoverUI.armorText.text = shopSlot.item.armorModifier.ToString();
        hoverUI.skillText.text = shopSlot.item.skill;
        hoverUI.priceText.text = shopSlot.item.price.ToString();
    }

    public void HideItemInfo()
    {
        hoverUI.itemInfo.SetActive(false);
    }
}
