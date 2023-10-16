using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : MonoBehaviour
{
    public int damage = 1;

    private void OnCollisionEnter(Collision col)
    {
        DamageReceiver receiver = FindObjectOfType<DamageReceiver>();
        if (receiver != null)
        {
            receiver.Receiver(damage);
            UIManager.ins.UpdateHp(receiver.hp.ToString());
        }
    }
}
