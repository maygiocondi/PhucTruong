using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSupply : PoolingSupply<Bullet>
{
    static public BulletSupply ins;

    private void Awake()
    {
        if (ins == null)
        {
            ins = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
