using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyCombat : CharacterCombat
{
    EnemyStats enemyStats;
    EnemyController enemyController;
    //public event System.Action OnAttack;

    // Start is called before the first frame update
    void Start()
    {
        myStat = GetComponent<CharacterStats>();
        enemyStats = GetComponent<EnemyStats>();

        attackSpeed = 5f;
        attackCooldown = 2f;
        attackDelay = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        attackCooldown -= Time.deltaTime;
        enemyController = GetComponent<EnemyController>();
    }

    public override void Attack(CharacterStats targetStats, float distance)
    {
        base.Attack(targetStats, distance);
        if (attackCooldown <= 0f && !enemyStats.isHurt)
        {
            enemyController.animator.SetTrigger("Attack");
            StartCoroutine(DoDamage(targetStats, attackDelay, distance));

            //if (OnAttack != null)
            //    OnAttack();

            attackCooldown = 10f / attackSpeed;
        }
    }

    IEnumerator DoDamage(CharacterStats stats, float delay, float distance)
    {
        yield return new WaitForSeconds(delay);
        if(distance <= 2f)
        {
            stats.TakeDamage(enemyStats.damage);
        }

        if(PlayerStat.ins.onHpChangedCallback != null)
        {
            PlayerStat.ins.onHpChangedCallback.Invoke();
        }
    }
}
