using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ArrowSupply : PoolingSupply<Arrow>
{
    static public ArrowSupply ins;

    private void Awake()
    {
        if(ins == null)
        {
            ins = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


}
