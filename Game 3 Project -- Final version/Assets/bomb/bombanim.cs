using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombanim : MonoBehaviour {
    public int y = 0;
	// Use this for initialization
	void Start () {
        y = 0;
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.Euler(0, y, 0);
        y += 10;
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject x = collision.gameObject;

        if (x.gameObject.tag == "Plane" || x.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
        if(x.gameObject.tag == "Building")
        {
            Destroy(x);
        }
        
    } 
}
