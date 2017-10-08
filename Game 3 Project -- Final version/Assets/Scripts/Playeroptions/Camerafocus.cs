using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafocus : MonoBehaviour
{
    public GameObject Player;
    // Use this for initialization
    void Start()
    {
        gameObject.transform.position = Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject != null)
        {
            gameObject.transform.position = Player.transform.position;
            Vector3 x = new Vector3(0.0f, 10.0f, -1.0f);
            gameObject.transform.position += x;
        }

    }
}
