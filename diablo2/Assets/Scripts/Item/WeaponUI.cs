using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Inventory/Weapon")]
public class WeaponUI : MonoBehaviour
{

    static public WeaponUI ins;
    public GameObject[] weapons;
    public string weaponName;


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
    }

    private void Start()
    {
        ChangeSwordMesh();
        weaponName = "2H_Sword";
    }

    private void Update()
    {
        ChangeWeaponName();
    }

    public void ChangeSwordMesh()
    {
        foreach (var weapon in weapons)
        {
            if (weapon.name == "2H_Sword")
            {
                weapon.SetActive(true);
            }
            else
            {
                weapon.SetActive(false);
            }
        }
    }

    public void ChangeCrossBowMesh()
    {
        foreach (var weapon in weapons)
        {
            if (weapon.name == "crossbow_1handed")
            {
                weapon.SetActive(true);
            }
            else
            {
                weapon.SetActive(false);
            }
        }
    }

    public void ChangeStaffMesh()
    {
        foreach (var weapon in weapons)
        {
            if (weapon.name == "staff")
            {
                weapon.SetActive(true);
            }
            else
            {
                weapon.SetActive(false);
            }
        }
    }

    public void ChangeWeaponName()
    {
        foreach(var weapon in weapons)
        {
            if(weapon.gameObject.active == true)
            {
                weaponName = weapon.name;
            }
        }
    }
}

public enum WeaponName { crossbow_1handed,   staff };
