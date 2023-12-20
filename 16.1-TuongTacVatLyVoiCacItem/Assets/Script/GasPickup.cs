using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            var rc = FindAnyObjectByType<CarController>();
            rc.PickUpGas();
            Destroy(gameObject);
        }
    }
}
