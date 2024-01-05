using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : CharacterStats
{
    public static PlayerStat ins;

    public Stat maxHelth;
    public int currentHealth;

    public Stat damage;
    public Stat armor;

    public int gold;

    public delegate void OnGoldChanged();
    public OnGoldChanged onGoldChangedCallback;

    public delegate void OnHpChanged();
    public OnHpChanged onHpChangedCallback;


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
        gold = 500;
        maxHelth.AddModifier(100);
    }


    // Start is called before the first frame update
    void Start()
    {
        EquipmentManager.ins.onEquipmentChanged += OnEquipmentChanged;
        currentHealth = 100;

        maxHelth.AddModifier(100);
    }

    void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        if (newItem != null)
        {
            armor.AddModifier(newItem.armorModifier);
            damage.AddModifier(newItem.damageModifier);

        }
        if(oldItem != null)
        {
            armor.RemoveModifier(oldItem.armorModifier);
            damage.RemoveModifier(oldItem.damageModifier);
        }
    }


    public override void TakeDamage(int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;
        Debug.Log(transform.name + " take" + damage + " damage");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public override void Die()
    {
        base.Die();
        PlayerManager.ins.KillPlayer();
    }


}
