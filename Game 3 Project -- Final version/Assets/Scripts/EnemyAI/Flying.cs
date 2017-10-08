using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour
{

    public float speed;
    public AudioClip DestroyedClip;
    public AudioClip DamagedClip;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;   // needs to be the gameobject that physically represents the body child-object of the flying enemy (NOT ITS PARENT OBJECT!)
    public float FireCooldownTime;
    public float RadiusAllowingDropAttack;

    private GameObject player;
    private Vector3 destination;
    private float fireCooldownTimer;
    private bool coolingDown;
    private int health;
    private GameObject lastCollided;

    private void Awake()
    {
        //DontDestroyOnLoad(transform.gameObject);
    }

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        destination = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        coolingDown = false;
        health = 2;
        lastCollided = null;
    }

    // Update is called once per frame


    private void FixedUpdate()
    {
        if (player != null && gameObject != null)
        {

            float step = speed * Time.deltaTime;
            destination = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
            transform.LookAt(destination);
            transform.position = Vector3.MoveTowards(transform.position, destination, step);

            /*if (Vector3.Distance(transform.position, destination) <= RadiusAllowingDropAttack
                && fireCooldownTimer % (FireCooldownTime + 1.0f) == 0.0f)
            {
                DropOrdinance();
            }*/

            if (coolingDown)
            {
                if (fireCooldownTimer < FireCooldownTime)
                {
                    fireCooldownTimer += 1.0f * Time.deltaTime;
                }
                else
                {
                    fireCooldownTimer = 0.0f;
                    coolingDown = false;
                }
            }

            if (health <= 0)
            {
                AudioSource.PlayClipAtPoint(DestroyedClip, transform.position);
                Destroy(gameObject);

                GameDecider.score += 1;
                //GameDecider.losing += 1;
                //Destroy(gameObject);
            }
            if (Vector3.Distance(transform.position, destination) <= RadiusAllowingDropAttack && !coolingDown)
            {
                DropOrdinance();
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject x = collision.gameObject;
        if (x.gameObject.CompareTag("Bullet"))
        {
            if (lastCollided == null || lastCollided != x)
            {
                //Debug.Log("bullet registered only once");
                --health;
                lastCollided = x;
                AudioSource.PlayClipAtPoint(DamagedClip, transform.position);
            }
            //else Debug.Log("bullet registered again");

            Destroy(x.gameObject);
        }
    }

    private void DropOrdinance()
    {
        // may have to change depending on axis of gameobject
        Vector3 offset = /*bulletSpawn.up.normalized +*/ bulletSpawn.forward.normalized * bulletSpawn.lossyScale.z * 2.0f;
        //Debug.Log("Scale: " + bulletSpawn.lossyScale);

        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position + offset,
            Quaternion.AngleAxis(180.0f, bulletSpawn.right));

        //Quaternion.AngleAxis(90.0f, bulletSpawn.right)
        Destroy(bullet, 6.0f);
        coolingDown = true;
    }

    public int GetHealth()
    {
        return health;
    }
}