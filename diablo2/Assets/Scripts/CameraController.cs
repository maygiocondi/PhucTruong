using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;
    float currenZoom = 10f;
    float pitch = 2f;

    void Update()
    {
        transform.position = target.position - offset * currenZoom;
        transform.LookAt(target.position + Vector3.up * pitch);
    }

    void LateUpdate()
    {

    }
}
