using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// not sure how to check if sprite is active
public class Lifelead : MonoBehaviour {
    //public AudioClip a;
    public GameObject life1;
    public GameObject life2;
    public GameObject life3;

    // Use this for initialization
    public bool one_time;
    public bool two_time;
    public bool three_time;

    void Start () {
        one_time = true;
        two_time = false;
        three_time = false;
	}
	
	// Update is called once per frame
	void Update () {
        //GameObject x = life1
        if (GameDecider.health == 2 && one_time)
        {
            //AudioSource.PlayClipAtPoint(a, transform.position);
            Destroy(life3);
            one_time = false;
            two_time = true;
        }
        if (GameDecider.health == 1 && two_time)
        {
            //AudioSource.PlayClipAtPoint(a, transform.position);
            Destroy(life2);
            two_time = false;
            three_time = true;
        }
        if (GameDecider.health <= 0 && three_time)
        {
            //AudioSource.PlayClipAtPoint(a, transform.position);
            //causes collision to be a sound when player takes damage
            //could be useful if it is not enemy for example like a mine we'll see
            Destroy(life1);
            three_time = false;
            SceneManager.LoadScene("Loser...");
        }
    }
}
