using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegRmove : MonoBehaviour {
    public float rotateangle;
    public float direction;  
	void Start () {
        rotateangle = 0;
        direction = 1;
	}
	
	void FixedUpdate () {
        if(rotateangle >= 15)
        {
            direction = -direction;
        }
        if(rotateangle <= -15)
        {
            direction = -direction;
        }
        rotateangle += direction;
        transform.rotation = Quaternion.Euler(rotateangle, 0, 0);
	}
}
