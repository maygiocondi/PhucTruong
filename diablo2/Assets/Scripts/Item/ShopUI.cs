using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    [SerializeField] ItemSpawner itemShopSpawner;
    ItemShop[] itemsShop;

    public Transform itemsParent;

    ShopSlot[] slots;

    void Start()
    {
        slots = itemsParent.GetComponentsInChildren<ShopSlot>();
        itemsShop = itemShopSpawner.itemShops;
        UpdateUI();
    }


    void Update()
    {
        
    }

    void UpdateUI()
    {
        for (int i = 0; i < itemsShop.Length; i++)
        {
            if(itemsShop[i] != null)
            {
                slots[i].icon.sprite = itemsShop[i].icon;
                slots[i].icon.enabled = true;
                slots[i].name = itemsShop[i].name;
                
            }
        }
    }
}
