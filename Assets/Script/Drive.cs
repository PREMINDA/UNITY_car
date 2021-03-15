using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{
    [SerializeField] private WheelCollider WH;
    public float torque = 200;
    public float maxAngle = 30f;
    public GameObject Wheel;
    void Start()
    {
        WH = this.GetComponent<WheelCollider>();
    }

    
    void Update()
    {
        float VER = Input.GetAxis("Vertical");
        float HOS = Input.GetAxis("Horizontal");
        move(VER,HOS);
    }

    void move(float acceleration , float ang)
    {
        acceleration = Mathf.Clamp(acceleration, -1, 1);
        ang = Mathf.Clamp(ang, -1, 1) * maxAngle;
        float thrustTorque = acceleration * torque;
        WH.motorTorque = thrustTorque;
        WH.steerAngle = ang;
        Quaternion qut;
        Vector3 pos;
        WH.GetWorldPose(out pos,out qut);
        Wheel.transform.position = pos;
        Wheel.transform.rotation = qut;
    }
}
