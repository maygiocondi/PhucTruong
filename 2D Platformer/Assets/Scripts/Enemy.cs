using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator anim;
    [SerializeField] float maxHp;
    [SerializeField] float damage;
    [SerializeField] float moveSpeed;
    [SerializeField] float distance;
    [SerializeField] float attackRange;
    [SerializeField] float attackCooldown;
    UIEnemy uiEnemy;


    bool movingRight = true;
    [SerializeField] Transform distanceDetection;
    [SerializeField] Transform model;
    float currentHp;
    float attackTimer;
    bool isWalking;
    bool isDead;
    GameStates gameStates;

    void Awake()
    {
        anim = model.GetComponent<Animator>();
        attackTimer = 0;
        gameStates = GameStates.Playing;
        uiEnemy = GetComponent<UIEnemy>();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
    }

    void Update()
    {
        uiEnemy.UpdateHp(currentHp / maxHp);
        if (Player.ins.isDead) gameStates = GameStates.GameOver;
        if (gameStates == GameStates.GameOver)
        {

        }
        if (gameStates == GameStates.Playing)
        {
            anim.SetBool("isWalking", isWalking);
            attackTimer += Time.deltaTime;
            MoveAround();
        }
    }

    void MoveAround()
    {
        isWalking = false;
        RaycastHit2D raycastPlayer = Physics2D.Raycast(Player.ins.transform.position, Vector2.down, distance, 1 << 10);
        var playerPos = Player.ins.transform.position;
        var moveDirection = playerPos - transform.position;
        var distanceAttack = moveDirection.magnitude;
        if (raycastPlayer.collider && distanceAttack < 4f)
        {

            if (movingRight && moveDirection.normalized.x < 0)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                Attack(distanceAttack, moveDirection);
            }
            else if (!movingRight && moveDirection.normalized.x > 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                Attack(distanceAttack, moveDirection);
            }
            else
            {
                Attack(distanceAttack, moveDirection);
            }
        }
        else
        {
            isWalking = true;
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            RaycastHit2D distanceInfo = Physics2D.Raycast(distanceDetection.position, Vector2.down, distance, 1 << 10);
            if (distanceInfo.collider == false)
            {
                if (movingRight == true)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    movingRight = false;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    movingRight = true;
                }
            }
        }

    }

    public void TakeDamage(float damage)
    {
        anim.SetTrigger("hurt");
        currentHp -= damage;
        if (currentHp <= 0)
        {
            Die();
        }
    }

    public void Attack(float distanceAttack, Vector3 moveDirection)
    {
        if (distanceAttack >= 1.5f)
        {
            isWalking = true;
            transform.position += moveDirection.normalized * moveSpeed * Time.deltaTime;
        }
        else
        {
            transform.position = transform.position;
        }
        if (distanceAttack <= attackRange)
        {
            if (attackTimer >= attackCooldown)
            {
                anim.SetTrigger("attack");
                attackTimer = 0;
                Player.ins.TakeDamage(damage);
            }
        }

    }

    void Die()
    {
        isDead = true;
        Destroy(gameObject);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawLine(distanceDetection.position, new Vector3(distanceDetection.position.x, distanceDetection.transform.position.y - distance, distanceDetection.transform.position.z));
    }
    public enum GameStates
    {
        Playing,
        GameOver
    }
}
