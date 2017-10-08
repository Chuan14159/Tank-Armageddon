using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

//roll a ball tutorial
public class Player : MonoBehaviour {
    //from unity bullet tutorial
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    //public Vector3 move;
    //used Kyle's invulnerability code;
    public UnityEvent onBulletHit;
    private Animator anim;
    private bool isVulnerable = true;
    /// time delay
    public float BulletSpawnPositionScale = 1.4f;
    public float timeBetweenShots = 0.05f;  // Allow 3 shots per second
    public float ShotgunSpreadAngle = 60.0f;
    public float ShotgunCooldownTime = 5;
    public static float ShotgunCooldownMaxTime = 5.0f;   // by default
    public static float ShotgunCooldownTimer = 0.0f;
    public static bool ShotgunReady = true;
    //AudioSource audio;
    public AudioClip impact;

    private float timestamp;
    GameObject t;
    /// </summary>
    // Use this for initialization
    private bool Vulnerable
    {
        get
        {
            return isVulnerable;
        }
        set
        {
            isVulnerable = value;
            anim.SetBool("isVulnerable", isVulnerable);
        }
    }

    private void Awake()
    {
        // edit by David Jamgochian 3/7/2017: I commented out the line right below.
        //DontDestroyOnLoad(transform.gameObject);
        //audio = GetComponent<AudioSource>();
        //DontDestroyOnLoad(transform.gameObject);
        GameDecider.health = 3;
        t = GameObject.FindGameObjectWithTag("MainCamera");
        anim = GetComponent<Animator>();
        Vulnerable = true;
        onBulletHit.AddListener(() => {
            MakeInvulnerable();
        });

        ShotgunCooldownMaxTime = ShotgunCooldownTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject x = collision.gameObject;

        // edit by David Jamgochian 3/7/2017: I added "|| x.CompareTag("Bullet")" to the if-condition
        if (x.gameObject.CompareTag("Enemy") || (x.CompareTag("Badbullet") && x.transform.localScale.y >= 1.0f))
        {
            //audio.PlayOneShot(impact, 0.7F);
            //GameObject []t = GameObject.FindGameObjectsWithTag("MainCamera");
            //foreach(GameObject z in t)
            //{

            //}
            AudioSource.PlayClipAtPoint(impact, transform.position);
            Destroy(x.gameObject);
            if (Vulnerable)
            {
                GameDecider.health -= 2;
				//if (GameDecider.health <= -1800) {
				//	Destroy (gameObject);
				//	SceneManager.LoadScene ("Loser...");

				//}
                //Debug.Log("hi");
                anim.Play("Invulnerable");
                MakeInvulnerable();
                t.BroadcastMessage("DoShake");
            }
        }
        // smaller bullets do less damage
        else if (x.CompareTag("Badbullet") && x.transform.localScale.y < 1.0f)
        {
            //audio.PlayOneShot(impact, 0.7F);
            //GameObject []t = GameObject.FindGameObjectsWithTag("MainCamera");
            //foreach(GameObject z in t)
            //{

            //}
            AudioSource.PlayClipAtPoint(impact, transform.position);

            Destroy(x.gameObject);
            if (Vulnerable)
            {
                GameDecider.health -= 1;

                //if (GameDecider.health <= -1800) {
                //	Destroy (gameObject);
                //	SceneManager.LoadScene ("Loser...");

                //}
                //Debug.Log("hi");
                anim.Play("Invulnerable");
                MakeInvulnerable();
                t.BroadcastMessage("DoShake");
            }
        }

    }

    private void MakeVulnerable()
    {
        Vulnerable = true;
    }

    private void MakeInvulnerable()
    {
        Vulnerable = false;
        Invoke("MakeVulnerable", 1.5f);
    }

    //end of Invulnerable code
    void Start () {
        ShotgunCooldownTimer = 0.0f;

        //shotgunReady = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.timeScale == 1) Fire(); //mainGunFired = true;
        //else mainGunFired = false;

        if (Input.GetKeyDown(KeyCode.Q) && ShotgunReady && Time.timeScale ==1) FireShotgun(); //shotgunFired = true;
        //else shotgunFired = false;

        //if (mainGunFired || shotgunFired) Invoke("FixedUpdate")

        if (!ShotgunReady)
        {
            if (ShotgunCooldownTimer < ShotgunCooldownTime)
                ShotgunCooldownTimer += 1 * Time.deltaTime;
            else
            {
                ShotgunCooldownTimer = 0.0f;
                ShotgunReady = true;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        //recently added
        //Vector3 clamp = transform.position;
        //edit by David Jamgochian 3/1/2017
        //starts here
        // old code
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");

        // new code
        //float moveHorizontal = 0.0f;
        //float moveVertical = 0.0f;
        //Vector3 direction = new Vector3();
        //if (Input.GetKey(KeyCode.UpArrow)) moveVertical = speed;
        //if (Input.GetKey(KeyCode.DownArrow)) moveVertical = -speed;
        //if (Input.GetKey(KeyCode.LeftArrow)) moveHorizontal = -speed;
        //if (Input.GetKey(KeyCode.RightArrow)) moveHorizontal = speed;
        //clamp.x = Mathf.Clamp(clamp.x , -130f, 90f);
       // clamp.z = Mathf.Clamp(clamp.z , -50f, 50f);

        //transform.position = clamp;
        //if ((mainGunFired)){// GameDecider.currentTime >= timestamp &&) {
        //    //timestamp = GameDecider.currentTime + timeBetweenShots;
        //    Fire();
        //}

        //if (shotgunFired && ShotgunReady)
        //{
        //    FireShotgun();
        //}
        //1move = new Vector3(moveHorizontal, 0.0f, moveVertical);
        //transform.position += move * speed * Time.deltaTime;
    }

    //recently added
    void Fire()
    {


        // Create the Bullet from the Bullet Prefab
        //Transform bulleting = bulletSpawn.position;

        // edit by David Jamgochian 2/28/17 
        //starts here

        // old code
        /*var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);*/

        // edit by David Jamgochian 3/7/2017: I increased the scale of how far the bullet spawns to prevent the players
        // from doing damage to self. Just paste the line below over the old one.
        Vector3 offset = /*bulletSpawn.up.normalized +*/ bulletSpawn.up.normalized * bulletSpawn.lossyScale.y * 1.4f;
        //Debug.Log("Scale: " + bulletSpawn.lossyScale);

        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position + offset,
            bulletSpawn.rotation);
        // ends here

        Destroy(bullet, 3.0f);

    }

    void FireShotgun()
    {
        //Debug.Log("shotgun fired");
        Vector3 midOffset = /*bulletSpawn.up.normalized +*/ bulletSpawn.up.normalized * bulletSpawn.lossyScale.y 
            * BulletSpawnPositionScale;
        Vector3 leftOffset = (bulletSpawn.up.normalized - bulletSpawn.right.normalized).normalized 
            * bulletSpawn.lossyScale.y * BulletSpawnPositionScale;
        Vector3 rightOffset = (bulletSpawn.up.normalized + bulletSpawn.right.normalized).normalized
            * bulletSpawn.lossyScale.y * BulletSpawnPositionScale;
        //bulletSpawn.up.normalized * bulletSpawn.lossyScale.y * 1.4f;
        //Debug.Log("Scale: " + bulletSpawn.lossyScale);
        Quaternion leftBulletRotation = bulletSpawn.rotation;
        //leftBulletRotation.eulerAngles.z = 30.0f;
        //Quaternion.LookRotation(bulletSpawn.forward, Vector3.)
        //Quaternion.Euler(bulletSpawn)
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position + midOffset,
            bulletSpawn.rotation);
        var leftBullet = Instantiate(
            bulletPrefab,
            bulletSpawn.position + leftOffset,
            bulletSpawn.rotation*Quaternion.AngleAxis(ShotgunSpreadAngle, bulletSpawn.up));
        var rightBullet = Instantiate(
            bulletPrefab,
            bulletSpawn.position + rightOffset,
            bulletSpawn.rotation * Quaternion.AngleAxis(-ShotgunSpreadAngle, bulletSpawn.up));

        ShotgunReady = false;
        Destroy(bullet, 3.0f);
        Destroy(leftBullet, 3.0f);
        Destroy(rightBullet, 3.0f);
    }


    

}
