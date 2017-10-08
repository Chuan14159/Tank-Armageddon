using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public Canvas button1;
    public Canvas button2;
    public AudioClip clip;

    // Use this for initialization
    void Start()
    {

        button1.enabled = true;
        button2.enabled = false;

    }
    public void NextMenu() //this function will will be added in click event of any button i-e onClick() option
    {
        if (button2.enabled)
        {
            button2.enabled = false;
        }
        else
        {
            button2.enabled = true;
        }
    }
    public void ReturnMenu() //this function will will be added in click event of any button i-e onClick() option
    {
        Debug.Log("Return");
        button2.enabled = false;
        button1.enabled = true;
    }

}
