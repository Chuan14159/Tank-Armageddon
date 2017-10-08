using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Moveplayer : MonoBehaviour
{
    public float SPEED;
    public AudioClip clip;
    public AudioClip clip2;
    public static bool right_color = true;
    void Start()
    {

    }

    void Update()
    {
        GameObject x = GameObject.FindWithTag("Player");
        if(x != null)
        {
            float step = SPEED * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, x.transform.position, step);
        }

    }


    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject x = collision.gameObject;
        //Debug.Log (x.name);
        int[] dir = new int[2];
        dir[0] = -1;
        dir[1] = 1;
        if (x.CompareTag("Player"))
        {
            //GameDecider.losing += 1;
            AudioSource.PlayClipAtPoint(clip2, transform.position);

            Destroy(gameObject);
        }
        else if (x.CompareTag("Bullet"))
        {
            GameDecider.score += 1;
            AudioSource.PlayClipAtPoint(clip, transform.position);
            Destroy(gameObject);
        }


    }

}
