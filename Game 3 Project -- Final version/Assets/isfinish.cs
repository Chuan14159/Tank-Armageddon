using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isfinish : MonoBehaviour {
    public AudioClip impact;
	void Start () {
        gameObject.SetActive(true);
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(impact, transform.position);
            gameObject.SetActive(false);
        }
    }
}
