using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStat : EnemyStats
{

    // Start is called before the first frame update
    void Start()
    {
        maxHelth = 2000;
        currentHealth = maxHelth;

        damage = 100;
        isHurt = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
