using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float fowardSpeed;
    public float speed;
    public float currentSpeed;
    private float boostingSpeed = 0.0f;
    public bool isBoosting = false;
    public float boostingTime = 2.4f; //time in seconds
    public float boostTimeLeft;

    private Rigidbody  playerRB;
    private float horizontalMove;
    private float verticalMove;
    public ParticleSystem wallhit;
    private healthController hpControl;
    private WeaponSystem wSystem;

	// Use this for initialization
	void Start () {
        playerRB = GetComponent<Rigidbody>();
        hpControl = GetComponent<healthController>();
        wSystem = GetComponent<WeaponSystem>();
        boostTimeLeft = boostingTime;
        currentSpeed = fowardSpeed;

    }
	
	// Update is called once per frame
	void Update () {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
        if (Input.GetButtonDown("Fire1") && (wSystem.currentAmmo > wSystem.attackCost))
        {
            wSystem.FireWeapon(currentSpeed);
        }
        if (Input.GetButtonDown("Jump") && !isBoosting)
        {
            isBoosting = true;
            boostTimeLeft = boostingTime;
            wSystem.rechargeRate += 0.5f;
        }
	}
    private void FixedUpdate()
    {
        if (isBoosting) AddToBoost();
        currentSpeed += boostingSpeed;
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
            hpControl.TakeDamage(5.0f);
            playerRB.AddForce(dir * (speed * 5));
            Instantiate(wallhit, collisionPoint, Quaternion.Euler(dir),collision.gameObject.transform);
        }else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Vector3 collisionPoint = collision.contacts[0].point;
            Vector3 dir = collisionPoint - transform.position;
            dir = -dir.normalized;
            hpControl.TakeDamage(2.5f);
            playerRB.AddForce(dir * (speed * 10));
            Instantiate(wallhit, collisionPoint, Quaternion.Euler(dir), collision.gameObject.transform);
            Instantiate(wallhit, collisionPoint, Quaternion.Euler(dir), collision.gameObject.transform);
            Instantiate(wallhit, collisionPoint, Quaternion.Euler(dir), collision.gameObject.transform);
        }
    }

    private void AddToBoost()
    {
        boostingSpeed = (boostTimeLeft * boostTimeLeft) * 0.02f;
        wSystem.WeaponBoost(boostingSpeed * 7.5f);
        boostTimeLeft -= 0.02f;
        if(boostTimeLeft< 0.0f)
        {
            isBoosting = false;
        }
    }

}
