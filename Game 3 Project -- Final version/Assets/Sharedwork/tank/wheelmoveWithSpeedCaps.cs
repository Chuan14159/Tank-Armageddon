using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelmoveWithSpeedCaps : MonoBehaviour {

    public Quaternion rotate;
    public float x;
    public float y;
    public float z;
    public int angularSpeed;
    public float movementMagnitude;
    public float MinimumMoveSpeed;
    public float MaximumMoveSpeed;

    private Rigidbody rb;
    private bool leftArrowPressed;
    private bool rightArrowPressed;
    private bool upArrowPressed;
    private bool downArrowPressed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        x = 0;
        y = 0;
        z = 0;
        //angularSpeed = 2;
        //movementSpeed = 3;
        rotate = Quaternion.Euler(x, y, z);
        leftArrowPressed = false;
        rightArrowPressed = false;
        upArrowPressed = false;
        downArrowPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) leftArrowPressed = true;
        else leftArrowPressed = false;

        if (Input.GetKey(KeyCode.RightArrow)) rightArrowPressed = true;
        else rightArrowPressed = false;

        if (Input.GetKey(KeyCode.UpArrow)) upArrowPressed = true;
        else upArrowPressed = false;

        if (Input.GetKey(KeyCode.DownArrow)) downArrowPressed = true;
        else downArrowPressed = false;
    }

    void FixedUpdate()
    {
        if (leftArrowPressed)
        {
            y -= angularSpeed;
        }
        if (rightArrowPressed)
        {
            y += angularSpeed;
        }
        rotate = Quaternion.Euler(x, y, z);
        transform.rotation = rotate;
        if (upArrowPressed && rb.velocity.normalized == transform.forward.normalized && rb.velocity.magnitude <= MaximumMoveSpeed)
        {
            GetComponent<Rigidbody>().AddForce(transform.forward.normalized * movementMagnitude);
        }
        if (downArrowPressed && rb.velocity.normalized == -transform.forward.normalized && rb.velocity.magnitude <= MaximumMoveSpeed)
        {
            GetComponent<Rigidbody>().AddForce(-transform.forward.normalized * movementMagnitude);
        }
    }
}
