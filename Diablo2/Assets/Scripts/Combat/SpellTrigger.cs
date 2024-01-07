using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellTrigger : MonoBehaviour
{
  
    public LayerMask enemyLayer;


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger");

        if(other != null)
        {
            var enemy = other.GetComponent<EnemyStats>();
            enemy.TakeDamage(100);
        }

        //RaycastHit[] hits = Physics.SphereCastAll(contactPoint, 2f, Vector3.right, 1000f, enemyLayer);
        //Debug.Log("Raycasthit count" + hits.Length);
        //foreach (RaycastHit hit in hits)
        //{
        //    var enemy = hit.rigidbody.GetComponent<Enemy>();
        //    if (enemy != null)
        //    {
        //        enemy.myStat.TakeDamage(100);

        //    }
        //}
    }
}
