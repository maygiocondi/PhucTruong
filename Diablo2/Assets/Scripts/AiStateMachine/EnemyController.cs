using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public Animator animator;

    public bool isWaking;

    public float lookRadius = 10f;

    Transform target;
    NavMeshAgent agent;
    EnemyCombat combat;

    EnemyStats enemyStats;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.ins.player.transform;
        agent = GetComponent<NavMeshAgent>();
        combat = GetComponent<EnemyCombat>();
        enemyStats = GetComponent<EnemyStats>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isWalking", isWaking);

        float distance = Vector3.Distance(target.position, transform.position);
        if (distance < lookRadius)
        {
            agent.SetDestination(target.position);

            if (agent.velocity.magnitude > 0)
            {
                isWaking = true;
            }
            else
            {
                isWaking = false;
            }
            

            if (distance <= agent.stoppingDistance && !enemyStats.isHurt)
            {
                CharacterStats targetStats = target.GetComponent<CharacterStats>();
                if (targetStats != null)
                {

                    combat.Attack(targetStats, distance);
                }
                FaceTarget();
            }
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
