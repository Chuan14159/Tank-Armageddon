using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemybullet : MonoBehaviour
{
    public float SPEED;
    private Vector3 direction;
    public AudioClip clip;
    //public GameObject gun;
    //save position of gun before instantiate and use this direction to += it.
    // Use this for initialization
    void Start()
    {
        // edit by David Jamgochian 2/28/17 
        //starts here

        // old direction
        //direction = new Vector3(gun.transform.position.x, gun.transform.position.y, gun.transform.position.z);
        //FindObjectsOfType<>
        //direction = gun.transform.up.normalized;
        direction = transform.up.normalized;

        //ends here
        AudioSource.PlayClipAtPoint(clip, transform.position);

    }

    // Update is called once per frame
    void Update()
    {
        // edit by David Jamgochian 2/28/17 
        //starts here

        // old direction
        //direction = gun.transform.position;//new Vector3(gun.transform.position.x, gun.transform.position.y, gun.transform.position.z);

        //direction = gun.transform.up.normalized;
        //direction = transform.position.normalized;

        //ends here

        transform.position += direction * SPEED * Time.deltaTime;

    }
    private void OnCollisionEnter(Collision collision)
    {
        //GameObject x = collision.gameObject;
        ////if (x.CompareTag("Wall") || x.CompareTag("Alien home") || x.CompareTag("Enemy"))
        ////{
        ////    Destroy(gameObject);
        ////}
        //if (x.CompareTag("Enemy"))
        //{
        //    Destroy(gameObject);
        //}
    }
    //private void OnMouseUp()
    //{

    //    AudioSource.PlayClipAtPoint(clip, transform.position);
    //    direction = new Vector3(0.0f, 0.0f, 5.0f);
    //    DestroyObject(gameObject);

    //}
}