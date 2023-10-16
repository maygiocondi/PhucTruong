using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : MonoBehaviour
{
    public int hp;

    private void Start()
    {
        hp = 3;
    }

    public void Receiver(int damage)
    {
        hp -= damage;
    }

}
