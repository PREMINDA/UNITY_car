using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{
    [SerializeField] private WheelCollider WH;
    public float torque = 200;
    void Start()
    {
        WH = this.GetComponent<WheelCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        float VER = Input.GetAxis("Vertical");
        move(VER);
    }

    void move(float acceleration)
    {
        acceleration = Mathf.Clamp(acceleration, -1, 1);
        float thrustTorque = acceleration * torque;
        WH.motorTorque = thrustTorque;
    }
}
