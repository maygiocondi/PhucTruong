using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{
    public Image icon;

    public ItemShop itemShop;

    public Item item;

    public void BuyItem()
    {
        if (item.price <= PlayerStat.ins.gold)
        {
            bool wasBuyed = Inventory.ins.Add(item);
            if (wasBuyed)
            {
                PlayerStat.ins.gold -= item.price;
                if (PlayerStat.ins.onGoldChangedCallback != null)
                    PlayerStat.ins.onGoldChangedCallback.Invoke();
            }
        }
    }
}
