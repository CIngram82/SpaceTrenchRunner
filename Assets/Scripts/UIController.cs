using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Image healthGreenImage;
    public Image healthRedImage;

	// Use this for initialization
	void Start () {
       

    }
	
	// Update is called once per frame
	void Update () {
       
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
}
