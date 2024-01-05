using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class Enemy : Interactable
{
    PlayerManager playerManager;
    public EnemyStats myStat;

    private void Start()
    {
        playerManager = PlayerManager.ins;
        myStat = GetComponent<EnemyStats>();
    }


    private void Update()
    {
        UpdateRadius();
        if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance <= radius && PlayerMotor.ins.isFacingRight)
            {
                Interact();
                hasInteracted = true;
            }
            if (radius == 0)
                return;
        }
    }

    public override void Interact()
    {
        base.Interact();
        CharacterCombat playerCombat = playerManager.player.GetComponent<CharacterCombat>();
        if (playerCombat != null)
        {
            playerCombat.Attack(myStat);
        }
    }

    public void UpdateRadius()
    {
        switch (WeaponUI.ins.weaponName)
        {
            case "2H_Sword":
                radius = 2f;
                break;
            case "crossbow_1handed":
                radius = 7f;
                break;
            case "staff":
                radius = 7f;
                break;
            default:
                radius = 0;
                break;
        }
    }
}

