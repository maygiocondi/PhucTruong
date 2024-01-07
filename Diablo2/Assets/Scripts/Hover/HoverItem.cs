using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HoverItem : Hover
{
    ItemPickup itemPickup;




    private void Start()
    {
        itemPickup = GetComponent<ItemPickup>();
        hoverUI = HoverUI.ins;
    }

    public override void ShowItemInfo()
    {
        base.ShowItemInfo();
        hoverUI.itemInfo.SetActive(true);
        hoverUI.damageText.text = itemPickup.item.damageModifier.ToString();
        hoverUI.armorText.text = itemPickup.item.armorModifier.ToString();
        hoverUI.skillText.text = itemPickup.item.skill;
        hoverUI.priceText.text = itemPickup.item.price.ToString();
    }
}
