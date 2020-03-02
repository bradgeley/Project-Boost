using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody rocket;
    enum Direction { Left, Right };

    // Start is called before the first frame update
    void Start()
    {
        rocket = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        processInput();
    }

    private void processInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Thrust();
        }
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            Turn(Direction.Left);
        }
        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            Turn(Direction.Right);
        }
    }

    private void Turn(Direction d)
    {
        switch (d)
        {
            case Direction.Left:
                transform.Rotate(Vector3.forward);
                break;
            case Direction.Right:
                transform.Rotate(Vector3.back);
                break;
        }
    }

    private void Thrust()
    {
        rocket.AddRelativeForce(Vector3.up);
    }
}
