using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float speed;
    float accelerate;
    float maxSpeed;

    bool movement = true;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.5f;
        accelerate = 0.05f;
        maxSpeed = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (movement)
        {
            cameraMovement();
        }
    }

    void cameraMovement()
    {
        transform.position += transform.up*speed*Time.deltaTime;
        speed += accelerate * Time.deltaTime;
        if (speed>maxSpeed) 
        { 
            speed=maxSpeed;
        }
    }
}
