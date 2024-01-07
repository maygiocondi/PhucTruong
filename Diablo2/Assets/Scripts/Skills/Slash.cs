using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour
{

    float existTimer = 0f;


    // Update is called once per frame
    void Update()
    {
        existTimer += Time.deltaTime;
        if (existTimer > 0.5)
        {
            DespawnProjectile();
        }
    }

    private void DespawnProjectile()
    {
        transform.gameObject.SetActive(false);
    }
}
