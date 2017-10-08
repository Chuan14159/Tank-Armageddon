using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifelead : MonoBehaviour {

    public GameObject life1;
    public GameObject life2;
    public GameObject life3;
    public GameObject parentEnemy;
    //public FollowAndShoot groundAI;

    // Use this for initialization
    public bool one_time = true;
    public bool two_time = false;
    public bool three_time = false;
    private FollowAndShoot groundAI;
    private Flying flyingAI;
    void Start()
    {
        //one_time = true;
        //two_time = false;
        //three_time = false;
        groundAI = parentEnemy.GetComponent<FollowAndShoot>();

        if (groundAI == null)
            flyingAI = parentEnemy.GetComponent<Flying>();
    }

    // Update is called once per frame
    void Update()
    {
        if (groundAI != null)
        {
            //GameObject x = life1
            if (groundAI.GetHealth() <= 2 && one_time)
            {
                //AudioSource.PlayClipAtPoint(a, transform.position);
                Destroy(life3);
                one_time = false;
                two_time = true;
            }
            if (groundAI.GetHealth() <= 1 && two_time)
            {
                //AudioSource.PlayClipAtPoint(a, transform.position);
                Destroy(life2);
                two_time = false;
                three_time = true;
            }
            if (groundAI.GetHealth() <= 0 && three_time)
            {
                //AudioSource.PlayClipAtPoint(a, transform.position);
                //causes collision to be a sound when player takes damage
                //could be useful if it is not enemy for example like a mine we'll see
                Destroy(life1);
                three_time = false;
            }
        }

        else
        {
            if (flyingAI.GetHealth() <= 2 && one_time)
            {
                //AudioSource.PlayClipAtPoint(a, transform.position);
                Destroy(life3);
                one_time = false;
                two_time = true;
            }
            if (flyingAI.GetHealth() <= 1 && two_time)
            {
                //AudioSource.PlayClipAtPoint(a, transform.position);
                Destroy(life2);
                two_time = false;
                three_time = true;
            }
            if (flyingAI.GetHealth() <= 0 && three_time)
            {
                //AudioSource.PlayClipAtPoint(a, transform.position);
                //causes collision to be a sound when player takes damage
                //could be useful if it is not enemy for example like a mine we'll see
                Destroy(life1);
                three_time = false;
            }
        }
    }
}
