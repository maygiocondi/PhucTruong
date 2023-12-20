using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spedometer : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CalcSpeed());
    }

    IEnumerator CalcSpeed()
    {
        bool isPlaying = true;
        while (isPlaying)
        {
            Vector3 prevPos = transform.position;

            yield return new WaitForFixedUpdate();

            speed = Mathf.RoundToInt(Vector3.Distance(transform.position, prevPos) *5f / Time.fixedDeltaTime);
            UIManager.ins.UpdateSpeed(speed.ToString());
        }
    }
}
