using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Movementvers1 : MonoBehaviour
{
    bool isWalking;

    public Interactable focus;

    [SerializeField] Animator anim;
    NavMeshAgent agent;
    Camera m_Camera;
    Vector3 cameraToPlayerVector;
    PlayerMotor playerMotor;

    void Awake()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        playerMotor = GetComponent<PlayerMotor>();
        m_Camera = Camera.main;
        //cameraToPlayerVector = m_Camera.transform.position - transform.position;
    }

    private void Start()
    {

    }

    private void Update()
    {
        if(agent.velocity.magnitude > 0)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
        anim.SetBool("isWalking", isWalking);
        GetInput();
        //m_Camera.transform.position = transform.position + cameraToPlayerVector;
    }

    void GetInput()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = m_Camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, 1 << 8))
            {
                playerMotor.MoveToPoint(hit.point);
                RemoveFocus();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = m_Camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, 1 << 8))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    SetFocus(interactable);
                }
            }
        }
    }

    void SetFocus(Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
                focus.OnDefocused();
            focus = newFocus;
            playerMotor.FollowTarget(newFocus);
        }
        newFocus.OnFocused(transform);

    }

    void RemoveFocus()
    {
        if (focus != null)
            focus.OnDefocused();

        focus = null;
        playerMotor.StopFollowingTarget();
    }
}

