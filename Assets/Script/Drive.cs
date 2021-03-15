using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{
    [SerializeField] private WheelCollider WH;
    public float torque = 200;
    public GameObject Wheel;
    void Start()
    {
        WH = this.GetComponent<WheelCollider>();
    }

    
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
        Quaternion qut;
        Vector3 pos;
        WH.GetWorldPose(out pos,out qut);
        Wheel.transform.position = pos;
        Wheel.transform.rotation = qut;
    }
}
