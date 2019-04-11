using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float forwardSpeed;
    public float speed;
    public float minSpeed = 15.0f;

    private bool playerDead = false;

    [Header("Camera FOV system")]
    private Camera myCamera;
    public float normalFOV = 60;
    public float boostFOV = 65;
    public float breakFOV = 55;
    public float fOVChangeRate = 0.075f;

    // boosting
    [HideInInspector]   public float currentSpeed;
    [HideInInspector]   public bool isBoosting = false;
    [HideInInspector]   public float boostTimeLeft;
    public float boostingTime = 2.4f; //time in seconds


    //breaking
    [HideInInspector]   public bool isBreaking = false;
    [HideInInspector]   public float breakingTimeLeft;
    public float breakingTime = 1.0f; //time in seconds
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
    private SceneController scnControl;
    private AudioManager audioMan;

    // Use this for initialization
    void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        audioMan = FindObjectOfType<AudioManager>();
        playerRB = GetComponent<Rigidbody>();
        wSystem = GetComponent<WeaponSystem>();

        scnControl = FindObjectOfType<SceneController>();
        uiControl = FindObjectOfType<UIController>();
        
        boostTimeLeft = boostingTime;
        breakingTimeLeft = breakingTime;
        currentSpeed = forwardSpeed;
        health = maxHealth;

        myCamera = FindObjectOfType<Camera>();

    }
	
	// Update is called once per frame
	void Update () {

        if (!playerDead)
        {
            horizontalMove = Input.GetAxis("Horizontal");
            verticalMove = Input.GetAxis("Vertical");
            if (Input.GetButtonDown("Fire1") && (wSystem.currentAmmo > wSystem.attackCost))
            {
                wSystem.FireWeapon(currentSpeed);
                audioMan.PlayAttackSFX();
            }
            else if (Input.GetButtonDown("Fire1") && (wSystem.currentAmmo < wSystem.attackCost))
            {
                audioMan.PlaylowPowerAttackVO();
            }
            if (Input.GetButtonDown("Jump") && !isBoosting && !isBreaking)
            {
                isBoosting = true;
                minSpeed += 1;
                boostTimeLeft = boostingTime;
                audioMan.hasBoosted = true;
                audioMan.PlayboosingAttackVO();
            }
            if (Input.GetButtonDown("Fire2") && !isBreaking && !isBoosting)
            {
                isBreaking = true;
                audioMan.hasBreaked = true;
                breakingTimeLeft = breakingTime;

                if (wSystem.currentAmmo < breakingCost)
                {
                    TakeDamage((breakingDamage + breakingCost) - wSystem.currentAmmo);
                    wSystem.currentAmmo = 0.0f;
                    audioMan.PlaylowPowerBreakingDamageVO();
                }
                else
                {
                    TakeDamage(breakingDamage);
                    wSystem.currentAmmo -= breakingCost;
                }
            }

            



            // FOV returns to normal 
            if (!isBoosting && !isBreaking && !playerDead && (myCamera.fieldOfView != 60))
            {
                myCamera.fieldOfView = Mathf.Lerp(myCamera.fieldOfView, normalFOV, fOVChangeRate);
            }

            
        }
        if (playerDead)
        {
            DeathFOV();
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
            playerRB.AddForce(dir * (speed * 10));
            Instantiate(wallhit, collisionPoint, Quaternion.Euler(dir),collision.gameObject.transform);
            audioMan.PlaycollisionVO();
        }else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Vector3 collisionPoint = collision.contacts[0].point;
            Vector3 dir = collisionPoint - transform.position;
            dir = -dir.normalized;
            TakeDamage(obsHitDamage);
            audioMan.PlaycollisionVO();
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

        // FOV change
        myCamera.fieldOfView = Mathf.Lerp(myCamera.fieldOfView, boostFOV, fOVChangeRate);
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
        // FOV change
        myCamera.fieldOfView = Mathf.Lerp(myCamera.fieldOfView, breakFOV, fOVChangeRate);
    }

    private void TakeDamage(float damage)
    {
        health -= damage;
        uiControl.UpdateHealthDisplay(health);
        if (health <= 0.0f)
        {
            PlayerDeath();
        }
    }


    //NOT FINISHED

    private void PlayerDeath()
    {
        Cursor.lockState = CursorLockMode.None;

        minSpeed = 0;
        forwardSpeed = 0;
        currentSpeed = 0;

        playerDead = true;

        StartCoroutine(loadCredits());
       
    }
    IEnumerator loadCredits()
    {

        yield return new WaitForSeconds(2.5f);
        Cursor.visible = true;
        FindObjectOfType<MusicManager>().PlayMenuMusic();
        scnControl.LoadSceneByName("GameOver");
        
    }

    public void DeathFOV()
    {
        Camera.main.fieldOfView += Time.deltaTime * 40;
    }
}
