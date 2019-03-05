using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthController : MonoBehaviour {
    public float maxHealth = 100;
    private float health;
    private UIController uiControl;

	// Use this for initialization
	void Start () {
        uiControl = GameObject.Find("UIController").GetComponent<UIController>();
        health = maxHealth;
	}

    public void TakeDamage(float damage)
    {
        health -= damage;
        uiControl.UpdateHealthDisplay(health);
    }
}
