using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Rigidbody rb;
    public float existTimer;
    public Transform enemy;

    void Update()
    {
        existTimer += Time.deltaTime;
        if (existTimer > 1f)
        {
            DespawnProjectile();
        }
    }

    public void Shoot(Vector3 dir)
    { 
        rb.velocity = dir * speed;
    
    }

    private void DespawnProjectile()
    {
        transform.gameObject.SetActive(false);
        PlayerCombat.ins.bullets.Remove(this);
        existTimer = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            transform.position = Vector3.zero;
        }
    }
}
