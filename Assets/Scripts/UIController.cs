﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Image healthGreenImage;
    public Image healthRedImage;
    public Text distanceNumText;

    private GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");

    }
	
	// Update is called once per frame
	void Update () {
        UpdateDistanceDisplay();
    }
    public void UpdateHealthDisplay(float health)
    {
        float newX = (health) * 0.01f;

        Vector2 max = healthGreenImage.rectTransform.anchorMax;
        max.x = newX;
        healthGreenImage.rectTransform.anchorMax = max;

        Vector2 min = healthRedImage.rectTransform.anchorMin;
        min.x = newX;
        healthRedImage.rectTransform.anchorMin = min;
    }
    public void UpdateDistanceDisplay()
    {
        float distance = player.transform.position.z;
        distanceNumText.text = distance.ToString("n1");
    }
}
