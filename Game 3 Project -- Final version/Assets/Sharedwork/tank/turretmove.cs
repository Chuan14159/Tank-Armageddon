using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class turretmove : MonoBehaviour {
    public wheelmove tank;
    public Quaternion rotate;
    public float x;
    public float y;
    public float z;
    public int speed;
    public GameObject barrel;
    public UnityEvent PointingAtTarget;
    public UnityEvent NotPointingAtTarget;

    private float horizontalAimingSpeed;
    private float defaultVerticalAimingSpeed;
    private float verticalAimingSpeed;
    private bool aPressed;
    private bool dPressed;
    private bool wPressed;
    private bool sPressed;

    private void Awake()
    {
        if (PointingAtTarget == null)
            PointingAtTarget = new UnityEvent();
        if (NotPointingAtTarget == null)
            NotPointingAtTarget = new UnityEvent();
    }

    void Start () {
        x = tank.x;
        y = tank.y;
        z = tank.z;
        speed = 5;
        rotate = Quaternion.Euler(x, y, z);

        aPressed = false;
        dPressed = false;
        wPressed = false;
        sPressed = false;
        horizontalAimingSpeed = speed;
        defaultVerticalAimingSpeed = 2.0f;
        verticalAimingSpeed = defaultVerticalAimingSpeed;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A)) aPressed = true;
        else aPressed = false;

        if (Input.GetKey(KeyCode.D)) dPressed = true;
        else dPressed = false;

        if (Input.GetKey(KeyCode.W)) wPressed = true;
        else wPressed = false;

        if (Input.GetKey(KeyCode.S)) sPressed = true;
        else sPressed = false;
    }

    void FixedUpdate () {
        Vector3 origin = barrel.transform.position + barrel.transform.up.normalized * 2.0f;
        RaycastHit hit;
        //bool pointingAtObject = Physics.Raycast(origin, barrel.transform.up.normalized, out hit);
        //Debug.DrawRay(origin, barrel.transform.up.normalized * 50.0f, Color.blue);
        if (Physics.SphereCast(origin, barrel.transform.lossyScale.y * 2.5f, barrel.transform.up.normalized, out hit, Mathf.Infinity) 
            /*Physics.Raycast(origin, barrel.transform.up.normalized, out hit)*/)
        {
            //Debug.Log(hit.collider.tag);
            if (hit.collider.CompareTag("Enemy"))
            {
                PointingAtTarget.Invoke();
                horizontalAimingSpeed = 1.0f;
                verticalAimingSpeed = 0.5f;
            }

            else
            {
                NotPointingAtTarget.Invoke();
                horizontalAimingSpeed = speed;
                verticalAimingSpeed = defaultVerticalAimingSpeed;
            }
            //Physics.SphereCast(origin, barrel.transform.lossyScale.x, barrel.transform.up.normalized, out hit);
        }

        else
        {
            NotPointingAtTarget.Invoke();
            horizontalAimingSpeed = speed;
            verticalAimingSpeed = defaultVerticalAimingSpeed;
        }

        if (wPressed)
        {
            x -= verticalAimingSpeed;
        }
        if (sPressed)
        {
            x += verticalAimingSpeed;
        }
        if (x > 0) x = 0;
        if (x < -80) x = -80;
        if (aPressed)
        {
            y -= horizontalAimingSpeed;
        }
        if (dPressed)
        {
            y += horizontalAimingSpeed;
        }
        if (y > tank.y + 90) y = tank.y + 90;
        if (y < tank.y - 90) y = tank.y - 90;
        rotate = Quaternion.Euler(x, y, z);
        transform.rotation = rotate;
    }
}
