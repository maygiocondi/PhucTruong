using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;



public class EquipmentManager : MonoBehaviour
{
    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    public event OnEquipmentChanged OnChanged;

    static public EquipmentManager ins;

    public Equipment[] currentEquipment;


    public delegate void OnEquiptChanged();
    public OnEquiptChanged onEquiptChanged;

    Inventory inventory;

    private void Awake()
    {
        if (ins == null)
        {
            ins = this;
        }
        else
        {
            Destroy(gameObject);
        }

        inventory = Inventory.ins;
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
    }

    private void Start()
    {
        
    }

    public void Equip(Equipment newItem)
    {
        int slotIndex = (int)newItem.equipSlot;
        Equipment oldItem = null;

        if(slotIndex == 7)
        {
            Vector3 start = new Vector3(131, 22, -11);
            inventory.Remove(newItem);
            Movementvers1.ins.transform.position = start;
            PlayerMotor.ins.MoveToPoint(start);
            Movementvers1.ins.RemoveFocus();
        }

        if (slotIndex == 6)
        {
            inventory.Remove(newItem);
            PlayerStat.ins.currentHealth += newItem.healModifier;
            if(PlayerStat.ins.currentHealth >= PlayerStat.ins.maxHelth.GetValue())
            {
                PlayerStat.ins.currentHealth = PlayerStat.ins.maxHelth.GetValue();
            }

            if (PlayerStat.ins.onHpChangedCallback != null)
            {
                PlayerStat.ins.onHpChangedCallback.Invoke();
            }
        }

        else
        {

            if (currentEquipment[slotIndex] != null)
            {
                oldItem = currentEquipment[slotIndex];
                inventory.Add(oldItem);
            }

            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(newItem, oldItem);
            }


            currentEquipment[slotIndex] = newItem;

            if (onEquiptChanged != null)
            {
                onEquiptChanged.Invoke();
            }
        }

    }

    public void Unequip(int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            // Add the item to the inventory
            Equipment oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);
            currentEquipment[slotIndex] = null;

            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItem);
            }

            if (onEquiptChanged != null)
            {
                onEquiptChanged.Invoke();
            }

        }

    }

    public void UnequipAll()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            Unequip(i);
        }
    }

    void Update()
    {
        // Unequip all items if we press U
        if (Input.GetKeyDown(KeyCode.U))
            UnequipAll();
    }
}
