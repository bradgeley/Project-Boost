using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    //Game Data
    const float MAX_FUEL = 100;

    //Global Variables
    [SerializeField] float thrustPower = 1750f;
    [SerializeField] float rotationPower = 250f;
    [SerializeField] float fuel;

    //Game Objects
    Rigidbody rocket;
    AudioSource thrust;
    enum Direction { Left, Right };

    // Start is called before the first frame update
    void Start()
    {
        rocket = GetComponent<Rigidbody>();
        thrust = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ManageThrust();
        ManageRotation();
    }

    private void ManageRotation()
    {
        rocket.freezeRotation = true; //take manual control of rotation
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * rotationPower);
        }
        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.back * Time.deltaTime * rotationPower);
        }
        rocket.freezeRotation = false; //resume physics
    }

    private void ManageThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rocket.AddRelativeForce(Vector3.up * Time.deltaTime * thrustPower);
            if (!thrust.isPlaying)
            {
                thrust.Play();
            }
        }
        else
        {
            thrust.Stop();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                print("OK");
                break;
            default:
                print("DEAD");
                break;
        }
    }
}
