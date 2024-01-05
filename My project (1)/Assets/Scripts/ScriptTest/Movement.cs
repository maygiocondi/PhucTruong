using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    bool isWalking;
    Vector3 moveDirection;
    Vector3 targetPoint;
    bool isTouchingWall;


    [SerializeField] Animator anim;
    [SerializeField] float moveSpeed;
    [SerializeField] float checkDistance;
    [SerializeField] Transform checker;

    private void Start()
    {
        anim = GetComponent<Animator>();
        targetPoint = transform.position;
    }

    private void Update()
    {
        anim.SetBool("isWalking", isWalking);
        CheckSurrounded();
        CheckInput();
        Move();
        Attack();
    }

    void CheckInput()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, 1 << 8))
            {
                if (hit.collider.tag == "Plane")
                {
                    targetPoint = hit.point;
                }

            }
        }
    }

    void Move()
    {
        moveDirection = targetPoint - transform.position;
        if (moveDirection.magnitude > 0.5f)
        {
            isWalking = true;
            transform.LookAt(targetPoint);
            transform.position += moveDirection.normalized * moveSpeed * Time.deltaTime;
        }
        else
        {
            isWalking = false;
        }

    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Attack");
        }
    }

    void CheckSurrounded()
    {
        
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z + checkDistance));
    }
}
