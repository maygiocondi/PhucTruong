using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float maxHp;
    [SerializeField] GameObject deadParticle;
    [SerializeField] GameObject model;
    UIPlayer uiPlayer;
    float currentHp;
    public bool isDead;

    static public Player ins;

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
        uiPlayer = GetComponent<UIPlayer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        uiPlayer.UpdateHp(currentHp / maxHp);
    }

    public void TakeDamage(float damage)
    {
        TestPlayerController.ins.anim.SetTrigger("Hurt");
        currentHp -= damage;
        if (currentHp <= 0)
        {
            Died();
        }
    }

    void Died()
    {
        isDead = true;
        Instantiate(deadParticle, transform.position, Quaternion.identity);
        model.SetActive(false);
    }


}
