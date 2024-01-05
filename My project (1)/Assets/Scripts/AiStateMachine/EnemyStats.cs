using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    public int maxHelth = 100;
    public int currentHealth;

    private void Start()
    {
        currentHealth = maxHelth;
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
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
        gameObject.SetActive(false);
        ItemSpawner.ins.SpawnItem(transform.position);
        EnemySpawner.ins.enemies.Remove(this.GetComponent<Enemy>());
    }
}
