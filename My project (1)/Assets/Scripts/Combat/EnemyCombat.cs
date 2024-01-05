using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : CharacterCombat
{
 
    //public event System.Action OnAttack;

    // Start is called before the first frame update
    void Start()
    {
        myStat = GetComponent<CharacterStats>();

        attackSpeed = 5f;
        attackCooldown = 2f;
        attackDelay = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        attackCooldown -= Time.deltaTime;
    }

    public override void Attack(CharacterStats targetStats)
    {
        base.Attack(targetStats);
        if (attackCooldown <= 0f)
        {
            StartCoroutine(DoDamage(targetStats, attackDelay));

            //if (OnAttack != null)
            //    OnAttack();

            attackCooldown = 10f / attackSpeed;
        }
    }

    IEnumerator DoDamage(CharacterStats stats, float delay)
    {
        yield return new WaitForSeconds(delay);
        stats.TakeDamage(5);

        if(PlayerStat.ins.onHpChangedCallback != null)
        {
            PlayerStat.ins.onHpChangedCallback.Invoke();
        }
    }
}
