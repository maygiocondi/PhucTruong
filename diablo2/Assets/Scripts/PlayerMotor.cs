using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMotor : MonoBehaviour
{
    static public PlayerMotor ins;

    public Transform target;
    private NavMeshAgent agent;

    public bool isFacingRight;

    private void Awake()
    {
        ins = this;
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        isFacingRight = true;
    }

    private void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
            FaceTarget(target.position);
            isFacingRight = true;
        }
    }

    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }

    public void FollowTarget(Interactable newTarget)
    {
        agent.stoppingDistance = newTarget.radius;
        agent.updateRotation = false;

        target = newTarget.transform;
    }

    public void StopFollowingTarget()
    {
        agent.stoppingDistance = 0f;
        agent.updateRotation = true;

        target = null;
    }

    public void FaceTarget(Vector3 target)
    {
        isFacingRight = false;
        Vector3 direction = (target - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 30f);
    }
}
