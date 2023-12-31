using System.Collections;
using UnityEngine;

public abstract class SkillBase : MonoBehaviour
{
    [SerializeField] protected SkillInfoBase skillInfo;
    protected Rigidbody2D rb;
    protected Movementvers1 controller => Movementvers1.ins;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    public abstract void CastSkill(Vector2 direction);
}
