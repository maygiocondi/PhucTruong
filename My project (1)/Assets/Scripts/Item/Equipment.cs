using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public ItemPickup itemPickup;

    public EquipmentSlot equipSlot;
    public WeaponSlot weaponSlot;

    public override void Use()
    {
        base.Use();
        if (equipSlot == EquipmentSlot.Weapon)
        {
            switch (weaponSlot)
            {
                case WeaponSlot.Sword:
                    EquipmentManager.ins.Equip(this);
                    WeaponUI.ins.ChangeSwordMesh();
                    RemoveFromInventory();
                    break;

                case WeaponSlot.Crossbow:
                    EquipmentManager.ins.Equip(this);
                    WeaponUI.ins.ChangeCrossBowMesh();
                    RemoveFromInventory();
                    break;

                case WeaponSlot.staff:
                    EquipmentManager.ins.Equip(this);
                    WeaponUI.ins.ChangeStaffMesh();
                    RemoveFromInventory();
                    break;

            }
        }
        EquipmentManager.ins.Equip(this);
        RemoveFromInventory();
    }

}

public enum EquipmentSlot { Weapon, Head, Armor, Feet, Legs, Shield, Heal, Tele }

public enum WeaponSlot { Sword, Crossbow, staff }
