using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;
using Unity.Mathematics;
using Unity.Burst.CompilerServices;

public class Movementvers1 : MonoBehaviour
{
    public static Movementvers1 ins;
    public Vector3 Position => transform.position;

    bool isWalking;
    public Interactable focus;

    [SerializeField] Animator anim;
    NavMeshAgent agent;
    public Camera cam;
    Vector3 cameraToPlayerVector;
    PlayerMotor playerMotor;

    void Awake()
    {
        if (ins == null)
        {
            ins = this;
        }
        else
        {
            Destroy(gameObject);
        }

        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        playerMotor = GetComponent<PlayerMotor>();
        cam = Camera.main;
        //cameraToPlayerVector = m_Camera.transform.position - transform.position;
    }

    private void Start()
    {
  
    }

    private void Update()
    {

        if (EventSystem.current.IsPointerOverGameObject())
            return;


        if (agent.velocity.magnitude > 0)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
        anim.SetBool("isWalking", isWalking);
        CheckItem();
        GetInput();
        //m_Camera.transform.position = transform.position + cameraToPlayerVector;

    }

    void GetInput()
    {
        if (PlayerCombat.ins.isAttack)
            return;

        if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;


            if (Physics.Raycast(ray, out hit, 100, 1 << 8))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    SetFocus(interactable);
                }
            }

            else if (Physics.Raycast(ray, out hit, 100, 1 << 10))
            {
                playerMotor.MoveToPoint(hit.point);
                RemoveFocus();
            }
        }

    }

    void CheckItem()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit))
        {
            HoverItem hover = hit.collider.GetComponent<HoverItem>();
            if (hover != null)
            {
                hover.ShowItemInfo();
            }
            else
            {
                HoverUI.ins.itemInfo.SetActive(false);
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

    public void RemoveFocus()
    {
        if (focus != null)
            focus.OnDefocused();

        focus = null;
        playerMotor.StopFollowingTarget();
    }


}

