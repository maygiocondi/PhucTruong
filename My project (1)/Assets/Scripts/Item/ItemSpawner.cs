using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public static ItemSpawner ins;

    public Equipment[] items;
    public ItemShop[] itemShops;
    [SerializeField] GameObject[] dropItems;
    private void Awake()
    {
        if(ins == null)
        {
            ins = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        for (int i = 0; i < itemShops.Length; i++)
        {
            if (items[i] != null)
            {
                itemShops[i].icon = items[i].icon;
                itemShops[i].name = items[i].name;
                itemShops[i].skill = items[i].skill;
                itemShops[i].armorModifier = items[i].armorModifier;
                itemShops[i].damageModifier = items[i].damageModifier;
                itemShops[i].healModifier = items[i].healModifier;
            }
        }
    }

    public void SpawnItem(Vector3 spawnPos)
    {
        int ranIndex = Random.Range(0, dropItems.Length);

        if (dropItems[ranIndex] != null)
        {
            var item = Instantiate(dropItems[ranIndex], spawnPos, Quaternion.identity);
        }
    }
}
