using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : CharacterCombat
{
    public static PlayerCombat ins;
    //public event System.Action OnAttack;
    string weaponName;

    [SerializeField] public BulletSupply bulletSupply;
    [SerializeField] public EffectSupply effectSupply;
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


    public override void Attack(CharacterStats targetStats)
    {
        base.Attack(targetStats);
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

                        break;
                    case "crossbow_1handed":

                        break;
                    case "staff":
                        player.RemoveFocus();
                        playerMotor.MoveToPoint(transform.position);
                        playerMotor.FaceTarget(hit.point);
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

    public void CastSpellSkill(Vector3 skillPos)
    {
        if (circleSpells.Count >= 1) return;
        //var clone = effectSupply.GetSupply(skillPos, Quaternion.identity);
        var clone = Instantiate(circleSpell, skillPos + fixSkill, Quaternion.identity);
        circleSpells.Add(clone);
        RaycastHit[] hits = Physics.SphereCastAll(skillPos, 2f, Vector3.right, 1000f, enemyLayer);
        Debug.Log("Raycasthit count" + hits.Length);
        foreach (RaycastHit hit in hits)
        {
            var enemy = hit.rigidbody.GetComponent<Enemy>();
            if (enemy != null)
            {
                //StartCoroutine(DoDamage(enemy.myStat, 0f));
                enemy.myStat.TakeDamage(100);
            }
        }

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

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, 2f);
    }
}
