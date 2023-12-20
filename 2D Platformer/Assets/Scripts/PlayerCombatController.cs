using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{
    Animator anim;
    public Transform model;
    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRange = 0.5f;
    [SerializeField] LayerMask enemyLayer;

    // Start is called before the first frame update
    void Start()
    {
        anim = model.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Attack();
        }
    }

    void Attack()
    {
        // Set animation
        anim.SetTrigger("Attack");

        // Deteck 
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (var enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(50);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
