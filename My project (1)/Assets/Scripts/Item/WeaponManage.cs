using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManage : MonoBehaviour
{

    public GameObject[] weaponTypes ;
    // Start is called before the first frame update
    void Start()
    {
        EquipmentManager.ins.OnChanged += EquipmentManager_OnEquipmentChanged;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EquipmentManager_OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        Debug.Log("Weapon change");
    }
}
