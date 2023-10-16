using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    DamageReceiver damageReceiver;

    public enum Axel
    {
        Front,
        Rear
    }

    [Serializable]
    public struct Wheel
    {
        public GameObject wheelModel;
        public WheelCollider wheelCollider;
        public Axel axel;
    }

    float maxAcceleration = 30.0f;
    float brakeAcceleration = 100.0f;

    float turnSensitiviti = 1.0f;
    float maxSteerAngle = 30.0f;

    Vector3 _centerOfMass;

    public List<Wheel> wheels;

    public float fuel;
    float m_currentFuel;

    float moveInput;
    float steerInput;

    private Rigidbody carRb;


    // Start is called before the first frame update
    void Start()
    {
        damageReceiver = GetComponent<DamageReceiver>();
        carRb = GetComponent<Rigidbody>();
        carRb.centerOfMass = _centerOfMass;
        m_currentFuel = fuel;
    }

    private void Update()
    {
        GetInputs();
        UIManager.ins.UpdateFilled(m_currentFuel / fuel);
    }

    private void LateUpdate()
    {
        Move();
        Steer();
        Brake();
    }

    void GetInputs()
    {
        moveInput = Input.GetAxis("Vertical");
        if(moveInput != 0)
        {
            m_currentFuel -= Time.deltaTime;
            if(m_currentFuel < 0)
            {
                m_currentFuel = 0;
            }
        }
        steerInput = Input.GetAxis("Horizontal");
    }

    void Move()
    {
        if (damageReceiver.hp <= 0 || m_currentFuel <= 0)
        {
            return;
        }
        foreach (var wheel in wheels)
        {
            wheel.wheelCollider.motorTorque = moveInput * maxAcceleration * 145 * Time.deltaTime;
        }
    }

    void Steer()
    {
        foreach (var wheel in wheels)
        {
            if (wheel.axel == Axel.Front)
            {
                var _steerAngle = steerInput * turnSensitiviti * maxSteerAngle;
                wheel.wheelCollider.steerAngle = Mathf.Lerp(wheel.wheelCollider.steerAngle, _steerAngle, 0.6f);
            }
        }
    }

    void Brake()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            foreach (var wheel in wheels)
            {
                wheel.wheelCollider.brakeTorque = 300 * brakeAcceleration * Time.deltaTime;
            }
        }
        else
        {
            foreach (var wheel in wheels)
            {
                wheel.wheelCollider.brakeTorque = 0;
            }
        }
    }

    public void PickUpGas()
    {
        m_currentFuel += 3;
        if(m_currentFuel > fuel)
        {
            m_currentFuel = fuel;
        }
    }

}
