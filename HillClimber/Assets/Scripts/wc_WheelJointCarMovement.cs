﻿using UnityEngine;
using System.Collections;

public class wc_WheelJointCarMovement : MonoBehaviour
{
	public WheelJoint2D frontwheel;
	public WheelJoint2D backwheel;

	JointMotor2D motorFront;
	JointMotor2D motorBack;

	public float speedF = 1000;
	public float speedB = 1000;

	public float torqueF = 100;
	public float torqueB = 100;


	public bool TractionFront = true;
	public bool TractionBack = true;


	public float carRotationSpeed = 250;

	// Update is called once per frame
	void Update()
	{
		if (Input.GetAxisRaw("Vertical") > 0)
		{
			if (TractionFront)
			{
				motorFront.motorSpeed = speedF * 1;
				motorFront.maxMotorTorque = torqueF;
				frontwheel.motor = motorFront;
			}

			if (TractionBack)
			{
				motorBack.motorSpeed = speedF * 1;
				motorBack.maxMotorTorque = torqueF;
				backwheel.motor = motorBack;

			}

		}
		else if (Input.GetAxisRaw("Vertical") < 0)
		{
			if (TractionFront)
			{
				motorFront.motorSpeed = speedB * -1;
				motorFront.maxMotorTorque = torqueB;
				frontwheel.motor = motorFront;
			}

			if (TractionBack)
			{
				motorBack.motorSpeed = speedB * -1;
				motorBack.maxMotorTorque = torqueB;
				backwheel.motor = motorBack;

			}

		}
		else
		{

			backwheel.useMotor = false;
			frontwheel.useMotor = false;

		}




		if (Input.GetAxisRaw("Horizontal") != 0)
		{

			GetComponent<Rigidbody2D>().AddTorque(carRotationSpeed * Input.GetAxisRaw("Horizontal") * -1);
		}

	}
}