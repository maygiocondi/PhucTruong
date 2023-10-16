using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEngine : MonoBehaviour
{
    private Rigidbody carRb;

    const float maxSpeed = 90f;

    public Transform path;
    float maxSteerAngle = 45f;
    public WheelCollider wheelFL;
    public WheelCollider wheelFR;

    List<Transform> nodes;
    int currectNode = 0;

    public Vector3 _centerOfMass;

    void Start()
    {
        carRb = GetComponent<Rigidbody>();
        carRb.centerOfMass = _centerOfMass;

        Transform[] pathTransform = path.GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();

        for (int i = 0; i < pathTransform.Length; i++)
        {
            if (pathTransform[i] != path.transform)
            {
                nodes.Add(pathTransform[i]);
            }
        }

    }

    void FixedUpdate()
    {
        ApplySteer();
        Drive();            
        CheckWaypointDistance();
    }

    void ApplySteer()
    {
        Vector3 relativeVector = transform.InverseTransformPoint(nodes[currectNode].position);
        float newSteer = (relativeVector.x / relativeVector.magnitude) * maxSteerAngle;
        wheelFL.steerAngle = newSteer;
        wheelFR.steerAngle = newSteer;
    }

    void Drive()
    {
        wheelFL.motorTorque = maxSpeed;
        wheelFR.motorTorque = maxSpeed;
    }

    void CheckWaypointDistance()
    {
        if (Vector3.Distance(transform.position, nodes[currectNode].position) <= 3f)
        {
            if (currectNode == nodes.Count - 1)
            {
                currectNode = 0;
            }
            else
            {
                currectNode++;
            }
        }
    }
}
