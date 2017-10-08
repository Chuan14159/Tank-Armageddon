using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehaviour : MonoBehaviour {

    public Image background;
    public Image fill;

    private Slider healthBar;
    private Color normalBackgroundColor;
    private Color fullHealthBackgroundColor;

    // Use this for initialization
    void Start () {
        healthBar = GetComponent<Slider>();
        normalBackgroundColor = background.color;
        fullHealthBackgroundColor = fill.color;
        healthBar.maxValue = GameDecider.health;
        healthBar.value = healthBar.maxValue;
        background.color = fullHealthBackgroundColor;
	}
	
	// Update is called once per frame
	void Update () {
        if (healthBar.value < healthBar.maxValue) background.color = normalBackgroundColor;
        healthBar.value = GameDecider.health;
	}
}
