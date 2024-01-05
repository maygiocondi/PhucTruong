using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Arrow : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float torque;
    float speed = 5f;
    float existTimer = 0f;

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        existTimer += Time.deltaTime;
        if (existTimer > 15)
        {
            DespawnProjectile();
        }
    }

    public void Move(Vector3 force)
    {
        rb.AddForce(force, ForceMode.Impulse);
    }

    public void OnTriggerEnter(Collider other)
    {
        var enemyCombat = other.GetComponent<EnemyCombat>();
        if(enemyCombat != null)
        {
            Debug.Log("trung");
        }

    }

    private void DespawnProjectile()
    {
        transform.gameObject.SetActive(false);
    }
}
