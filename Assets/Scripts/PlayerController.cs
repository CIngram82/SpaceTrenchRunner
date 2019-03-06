﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float fowardSpeed;
    public float speed;
    public float minSpeed = 15.0f;

    // boosting
    public float currentSpeed;

    public bool isBoosting = false;
    public float boostingTime = 2.4f; //time in seconds
    public float boostTimeLeft;
    //breaking
    public bool isBreaking = false;
    public float breakingTime = 1.0f; //time in seconds
    public float breakingTimeLeft;
    public float breakingCost = 50.0f;
    public float breakingDamage = 5.0f;

    // collision 
    public float wallHitDamage = 5.0f;
    public float obsHitDamage = 2.5f;


    // health
    public float maxHealth = 100;
    private float health;

    private Rigidbody  playerRB;
    private float horizontalMove;
    private float verticalMove;
    public ParticleSystem wallhit;
    private WeaponSystem wSystem;
    private UIController uiControl;

    // Use this for initialization
    void Start () {
        playerRB = GetComponent<Rigidbody>();
        uiControl = GameObject.Find("UIController").GetComponent<UIController>();
        wSystem = GetComponent<WeaponSystem>();
        boostTimeLeft = boostingTime;
        breakingTimeLeft = breakingTime;
        currentSpeed = fowardSpeed;
        health = maxHealth;

    }
	
	// Update is called once per frame
	void Update () {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
        if (Input.GetButtonDown("Fire1") && (wSystem.currentAmmo > wSystem.attackCost))
        {
            wSystem.FireWeapon(currentSpeed);
        }
        if (Input.GetButtonDown("Jump") && !isBoosting && !isBreaking)
        {
            isBoosting = true;
            minSpeed += 1;
            boostTimeLeft = boostingTime;
        }
        if (Input.GetButtonDown("Fire2")&& !isBreaking && !isBoosting)
        {
            isBreaking = true;
            breakingTimeLeft = breakingTime;
            
            if(wSystem.currentAmmo < breakingCost)
            {
                TakeDamage((breakingDamage + breakingCost) - wSystem.currentAmmo);
                wSystem.currentAmmo = 0.0f;
            }
            else
            {
                TakeDamage(breakingDamage);
                wSystem.currentAmmo -= breakingCost;
            }
        }
	}

    private void FixedUpdate()
    {
        if (isBoosting) AddToBoost();
        if (isBreaking) ApplyBreak();
        if (currentSpeed < minSpeed) currentSpeed = minSpeed;
        playerRB.velocity = transform.forward * (currentSpeed);

        Vector3 movement = transform.forward;
        movement.x = horizontalMove * speed;
        movement.y = verticalMove * speed;
        playerRB.AddForce( movement);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            Vector3 collisionPoint = collision.contacts[0].point;
            Vector3 dir = collisionPoint - transform.position;
            dir = -dir.normalized;
            TakeDamage(wallHitDamage);
            playerRB.AddForce(dir * (speed * 5));
            Instantiate(wallhit, collisionPoint, Quaternion.Euler(dir),collision.gameObject.transform);
        }else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Vector3 collisionPoint = collision.contacts[0].point;
            Vector3 dir = collisionPoint - transform.position;
            dir = -dir.normalized;
            TakeDamage(obsHitDamage);
            playerRB.AddForce(dir * (speed * 10));
            Instantiate(wallhit, collisionPoint, Quaternion.Euler(dir), collision.gameObject.transform);
            Instantiate(wallhit, collisionPoint, Quaternion.Euler(dir), collision.gameObject.transform);
            Instantiate(wallhit, collisionPoint, Quaternion.Euler(dir), collision.gameObject.transform);
        }
    }

    private void AddToBoost()
    {
        float boostingSpeed = (boostTimeLeft * boostTimeLeft) * 0.02f;
        currentSpeed += boostingSpeed;
        wSystem.WeaponBoost(boostingSpeed * 7.5f);
        boostTimeLeft -= 0.02f;
        if(boostTimeLeft< 0.0f)
        {
            boostingSpeed = 0.0f;
            isBoosting = false;
        }
    }
    private void ApplyBreak()
    {
        // speed drop
        float breakingSpeed = (breakingTimeLeft * breakingTimeLeft) * 0.3f;
        currentSpeed -= breakingSpeed;
        breakingTimeLeft -= 0.02f;
        if (breakingTimeLeft < 0.0f)
        {
            breakingSpeed = 0.0f;
            isBreaking = false;
        }

    }

    private void TakeDamage(float damage)
    {
        health -= damage;
        uiControl.UpdateHealthDisplay(health);
    }
}
