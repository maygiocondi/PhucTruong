using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    EnemyController controller;

    public int maxHelth = 100;
    public int currentHealth;

    public int damage = 10;

    public bool isHurt = false;


    private void Start()
    {
        currentHealth = maxHelth;
        controller = GetComponent<EnemyController>();
    }

    public override void TakeDamage(int damage)
    {
      
        base.TakeDamage(damage);
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;
        Debug.Log(transform.name + " take" + damage + " damage");

        controller.animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        } else
        {
            StartCoroutine(DoAnim());
        }


    }

    public override void Die()
    {
        base.Die();
        gameObject.SetActive(false);
        ItemSpawner.ins.SpawnItem(transform.position);
        EnemySpawner.ins.enemies.Remove(this.GetComponent<Enemy>());

    }

    IEnumerator DoAnim()
    {
        isHurt = true;
        yield return new WaitForSeconds(1f);
        isHurt = false;
    }
}
