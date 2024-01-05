using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SkillInfo/SwordAttack")]
public class AttackSkill : SkillBase
{
    public override void CastSkill(Vector2 direction)
    {
        RaycastHit[] hits = Physics.SphereCastAll(skillInfo.skillPos.position, 3f, Vector3.right, 1000f, 1 << 7);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }

}
