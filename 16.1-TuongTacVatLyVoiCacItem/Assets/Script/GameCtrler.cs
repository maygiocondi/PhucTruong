using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrler : MonoBehaviour
{
    public static GameCtrler ins;
    public DamageReceiver damageReceiver;

    private void Awake()
    {
        GameCtrler.ins = this;
        damageReceiver = GetComponent<DamageReceiver>();
    }
}
