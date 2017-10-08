using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelmove : MonoBehaviour {
    //public Quaternion rotate;
    //public float x;
    //public float y;
    //public float z;
    //public int angularSpeed;
    //public int movementSpeed;
    //void Start()
    //{
    //    x = 0;
    //    y = 0;
    //    z = 0;
    //    //angularSpeed = 2;
    //    //movementSpeed = 3;
    //    rotate = Quaternion.Euler(x, y, z);
    //}

    //void FixedUpdate()
    //{
    //    if (Input.GetKey(KeyCode.LeftArrow))
    //    {
    //        y -= angularSpeed;
    //    }
    //    if (Input.GetKey(KeyCode.RightArrow))
    //    {
    //        y += angularSpeed;
    //    }
    //    rotate = Quaternion.Euler(x, y, z);
    //    transform.rotation = rotate;
    //    if (Input.GetKey(KeyCode.UpArrow))
    //    {
    //        GetComponent<Rigidbody>().AddForce(transform.forward.normalized * movementSpeed);
    //    }
    //    if (Input.GetKey(KeyCode.DownArrow))
    //    {
    //        GetComponent<Rigidbody>().AddForce(-transform.forward.normalized * movementSpeed);
    //    }
    //}

    public Quaternion rotate;
    public float x;
    public float y;
    public float z;
    public int angularSpeed;
    public int movementSpeed;
    public float maxspeed;
    public float minspeed;
    public float speed;
    void Start()
    {
        speed = GetComponent<Rigidbody>().velocity.magnitude;
        x = 0;
        y = 0;
        z = 0;
        rotate = Quaternion.Euler(x, y, z);
    }

    void FixedUpdate()
    {
        speed = GetComponent<Rigidbody>().velocity.magnitude;
        //print(speed);
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            y -= angularSpeed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            y += angularSpeed;
        }
        rotate = Quaternion.Euler(x, y, z);
        transform.rotation = rotate;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (GetComponent<Rigidbody>().velocity.magnitude < minspeed && !Input.GetKey(KeyCode.KeypadPeriod))
            {
                GetComponent<Rigidbody>().velocity = transform.forward.normalized * minspeed;
            }
            if (Input.GetKey(KeyCode.Keypad0) && speed <= maxspeed)//accelerate
            {
                GetComponent<Rigidbody>().AddForce(transform.forward.normalized * movementSpeed * 4);
            }
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (GetComponent<Rigidbody>().velocity.magnitude < minspeed && !Input.GetKey(KeyCode.KeypadPeriod))
            {
                GetComponent<Rigidbody>().velocity = -transform.forward.normalized * minspeed;
            }
            if (Input.GetKey(KeyCode.Keypad0) && speed <= maxspeed)//accelerate
            {
                GetComponent<Rigidbody>().AddForce(-transform.forward.normalized * movementSpeed * 4);
            }
        }
        if (Input.GetKey(KeyCode.KeypadPeriod) && speed > minspeed)//decelarate
        {
            GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity * 0.8f;
        }
    }
}
