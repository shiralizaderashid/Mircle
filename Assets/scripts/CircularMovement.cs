using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = System.Random;
using UnityStandardAssets.CrossPlatformInput;

public class CircularMovement : MonoBehaviour
{

    [SerializeField]
    Transform rotationCenter;

    [SerializeField]
    float angularSpeed = 0.6f;

    private float rotationRadius;

   

    float posX, posY, angle = 0f;

    private float circleDistance;


    void Start()
    {
        rotationRadius = Vector3.Distance(transform.position, rotationCenter.position);
    }


	void FixedUpdate () {
        posX = rotationCenter.position.x  + Mathf.Cos (angle) * rotationRadius;
		posY = rotationCenter.position.y  + Mathf.Sin (angle) * rotationRadius;
		transform.position = new Vector2 (posX, posY);
        if (CrossPlatformInputManager.GetAxis("Horizontal") > 0)
        {
            angle = angle + Time.deltaTime * angularSpeed * CrossPlatformInputManager.GetAxis("Horizontal");
        }
        else
        {
            angle = angle + Time.deltaTime * angularSpeed;
        }
		

		if (angle >= 360f)
			angle = 0f;
	}

}
