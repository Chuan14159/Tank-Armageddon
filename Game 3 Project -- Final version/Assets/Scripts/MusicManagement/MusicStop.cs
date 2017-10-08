using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicStop : MonoBehaviour {
    public GameObject hand;

    // Use this for initialization
    void Start () {
        hand = GameObject.Find("BackgroundMusic");
        if (hand != null) { 
        hand.GetComponent<AudioSource>().volume = 0;
        }
    }
	

}
