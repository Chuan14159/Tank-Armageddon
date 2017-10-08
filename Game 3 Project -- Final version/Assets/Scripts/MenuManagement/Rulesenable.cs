using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rulesenable : MonoBehaviour {
    public Canvas canvas1;
    public Canvas canvas2;
    public AudioClip clip;
    // Use this for initialization
    void Start () {

        canvas1.enabled = true;
        canvas2.enabled = false;

    }
    public void NextMenu() //this function will will be added in click event of any button i-e onClick() option
    {
        canvas1.enabled = false;
        canvas2.enabled = true;
    }
    public void ReturnMenu() //this function will will be added in click event of any button i-e onClick() option
    {
        canvas2.enabled = false;
        canvas1.enabled = true;
    }

}
