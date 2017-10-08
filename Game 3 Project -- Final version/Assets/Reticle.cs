using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Reticle : MonoBehaviour {

    private GameObject player;
    private turretmove turret;
    private Image reticle;

	// Use this for initialization
	void Start () {
        reticle = GetComponent<Image>();
        player = GameObject.FindGameObjectWithTag("Player");
        //if (player != null)
        //{
        if (player != null)
        {
            turret = player.GetComponentInChildren<turretmove>();
            turret.PointingAtTarget.AddListener(TurnReticleRed);
            turret.NotPointingAtTarget.AddListener(TurnReticleWhite);
        }
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void TurnReticleRed()
    {
        reticle.color = new Color(1.0f, 0.0f, 0.0f, 0.5f);
    }

    public void TurnReticleWhite()
    {
        reticle.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
    }
}
