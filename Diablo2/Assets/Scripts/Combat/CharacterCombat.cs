using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    protected CharacterStats myStat;


    public float attackSpeed = 1f;
    protected float attackCooldown = 0f;

    protected float attackDelay = .6f;

    private void Start()
    {
        
    }

    private void Update()
    {

    }
    public virtual void Attack(CharacterStats targetStats, float distance)
    {
        
    }

   
}


