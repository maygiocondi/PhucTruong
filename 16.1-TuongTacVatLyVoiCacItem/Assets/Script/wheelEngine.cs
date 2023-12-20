using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelEngine : MonoBehaviour
{
    public Transform path;
    float maxSteerAngle = 45f;
    public WheelCollider wheel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        ApplySteer();
        Drive();
    }

    void ApplySteer()
    {
        Vector3 relativeVector = transform.InverseTransformPoint(path.position);
        float newSteer = (relativeVector.x / relativeVector.magnitude) * maxSteerAngle;
        wheel.steerAngle = newSteer;
    }

    void Drive()
    {
        wheel.motorTorque = 50f;
    }
}
