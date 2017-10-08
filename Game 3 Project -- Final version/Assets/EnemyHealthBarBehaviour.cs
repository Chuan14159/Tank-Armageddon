using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBarBehaviour : MonoBehaviour {

    public GameObject PlayerCamera;
    public FollowAndShoot ai;

    private TextMesh healthDisplay;

	// Use this for initialization
	void Start () {
        healthDisplay = GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
        healthDisplay.text = "Health: " + ai.GetHealth();
        transform.LookAt(-PlayerCamera.transform.position.normalized);
	}
}
