using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlayerCombat : CharacterCombat
{
    public static PlayerCombat ins;
    //public event System.Action OnAttack;
    string weaponName;

    [SerializeField] GameObject spellTrigger;
    [SerializeField] BulletSupply bulletSupply;
    [SerializeField] EffectSupply effectSupply;
    public List<Bullet> bullets = new List<Bullet>();
    public List<GameObject> circleSpells = new List<GameObject>();
    public Transform skillSpawnPos;
    public GameObject enemy;
    public LayerMask enemyLayer;

    public bool isAttack;

    float rangeDelay;

    Movementvers1 player;
    PlayerMotor playerMotor;
    public Transform slashSkillPos;
    public GameObject circleSpell;
    Vector3 fixSkill = new Vector3(0, 0.2f, 0);

    PlayerStat myStat;

    private void Awake()
    {
        ins = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        myStat = GetComponent<PlayerStat>();
        player = GetComponent<Movementvers1>();
        playerMotor = GetComponent<PlayerMotor>();
        weaponName = WeaponUI.ins.weaponName;
        attackSpeed = 1f;
        attackCooldown = .6f;
        attackDelay = .8f;
        rangeDelay = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        weaponName = WeaponUI.ins.weaponName;
        attackCooldown -= Time.deltaTime;
        GetInput();
    }


    public override void Attack(CharacterStats targetStats, float distance)
    {
        base.Attack(targetStats, 0f);
        switch (weaponName)
        {
            case "2H_Sword":
                if (attackCooldown <= 0f)
                {
                    AnimationController.ins.animator.SetTrigger("swordAttack");
                    StartCoroutine(DoDamage(targetStats, attackDelay));
                    //if (OnAttack != null)
                    //    OnAttack();

                    attackCooldown = 1f / attackSpeed;
                }
                break;
            case "crossbow_1handed":
                if (attackCooldown <= 0f)
                {
                    AnimationController.ins.animator.SetTrigger("rangeAttack");
                    StartCoroutine(DoAnim(0.5f, targetStats));
                    StartCoroutine(DoDamage(targetStats, rangeDelay));

                    attackCooldown = 0.5f;
                }
                break;
            case "staff":

                break;
        }
    }

    public void GetInput()
    {
        if (Input.GetMouseButton(1))
        {
            Ray ray = player.cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;


            if (Physics.Raycast(ray, out hit, 100, 1 << 10))
            {
                switch (WeaponUI.ins.weaponName)
                {
                    case "2H_Sword":
                        FaceAttack(hit.point);
                        AnimationController.ins.animator.SetTrigger("spellAttack");
                        SlashAttack(slashSkillPos.position);
                        break;
                    case "crossbow_1handed":
                        FaceAttack(hit.point);
                        RangeAttack(hit.point);
                        break;
                    case "staff":
                        FaceAttack(hit.point);
                        AnimationController.ins.animator.SetTrigger("spellAttack");
                        StartCoroutine(DoSkill(attackDelay, hit.point));
                        break;
                }
            }

        }
    }

    public void CastSkill(CharacterStats targetStats)
    {
        if (bullets.Count >= 1)
            return;
        var clone = bulletSupply.GetSupply(skillSpawnPos.position, Quaternion.identity);
        bullets.Add(clone);
        var dir = targetStats.transform.position - transform.position;
        clone.Shoot(dir.normalized);
    }

    public void SlashAttack(Vector3 skillPos)
    {

        RaycastHit hit;
        if (Physics.Raycast(skillPos, transform.forward, out hit, 10f, enemyLayer))
        {
            if (hit.collider.tag == "Enemy")
            {
                Debug.Log("Attack");
                hit.collider.GetComponent<EnemyStats>().TakeDamage(myStat.damage.GetValue());
            }
        }
    }

    public void RangeAttack(Vector3 targetPoint)
    {
        AnimationController.ins.animator.SetTrigger("rangeAttack");
        if (bullets.Count >= 1)
            return;
        var clone = bulletSupply.GetSupply(skillSpawnPos.position, Quaternion.identity);
        bullets.Add(clone);
        var dir = targetPoint - transform.position;
        clone.Shoot(dir.normalized);
    }

    public void CastSpellSkill(Vector3 skillPos)
    {
        if (circleSpells.Count >= 1) return;

        var clone = Instantiate(circleSpell, skillPos + fixSkill, Quaternion.identity);
        circleSpells.Add(clone);

    }

    IEnumerator DoDamage(CharacterStats stats, float delay)
    {
        isAttack = true;
        yield return new WaitForSeconds(delay);
        stats.TakeDamage(myStat.damage.GetValue());
        isAttack = false;
    }

    IEnumerator DoAnim(float attackDelay, CharacterStats targetStats)
    {
        isAttack = true;
        yield return new WaitForSeconds(attackDelay);
        CastSkill(targetStats);
        isAttack = false;
    }

    IEnumerator DoSkill(float delay, Vector3 skillPos)
    {
        isAttack = true;
        yield return new WaitForSeconds(delay);
        CastSpellSkill(skillPos);
        isAttack = false;
    }

    public void FaceAttack(Vector3 target)
    {
        player.RemoveFocus();
        playerMotor.MoveToPoint(transform.position);
        playerMotor.FaceTarget(target);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, 2f);
    }
}
