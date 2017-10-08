using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotgunStatusBarBehaviour : MonoBehaviour {
    
    public Image background;
    public Image fill;
    public Text message;

    private Slider shotgunBar;
    private Color rechargingBackgroundColor;
    private Color rechargedBackgroundColor;

    // Use this for initialization
    void Start()
    {
        shotgunBar = GetComponent<Slider>();
        rechargingBackgroundColor = background.color;
        rechargedBackgroundColor = fill.color;
        shotgunBar.maxValue = Player.ShotgunCooldownMaxTime;
        shotgunBar.value = Player.ShotgunCooldownTimer;
        background.color = rechargedBackgroundColor;
        message.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Player.ShotgunReady)
        {
            message.enabled = false;
            background.color = rechargingBackgroundColor;
            shotgunBar.value = Player.ShotgunCooldownTimer;
        }

        else
        {
            shotgunBar.value = shotgunBar.maxValue;
            background.color = rechargedBackgroundColor;
            message.enabled = true;
        }
    }
}
