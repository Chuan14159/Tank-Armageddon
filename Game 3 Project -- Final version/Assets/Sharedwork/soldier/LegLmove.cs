using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegLmove : MonoBehaviour {
    public LegRmove legR;
    void Start () {

	}
	
	void FixedUpdate () {
        transform.rotation = Quaternion.Euler(-legR.rotateangle, 0, 0);
    }
}
