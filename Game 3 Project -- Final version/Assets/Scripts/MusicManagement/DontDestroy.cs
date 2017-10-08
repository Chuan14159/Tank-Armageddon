using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour {
    // Use this for initialization
    private void Update()
    {
        GameObject[] objects;
        objects = GameObject.FindGameObjectsWithTag("Music");
        if (objects.Length > 1)
            Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }


}
