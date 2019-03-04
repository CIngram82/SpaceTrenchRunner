using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float fowardSpeed = 100.0f;
    public float speed = 100.0f;
    private Rigidbody  playerRB;
    private float horizontalMove;
    private float verticalMove;
    public ParticleSystem wallhit;
    private healthController hpControl;
	// Use this for initialization
	void Start () {
        playerRB = GetComponent<Rigidbody>();
        hpControl = GetComponent<healthController>();
	}
	
	// Update is called once per frame
	void Update () {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
	}
    private void FixedUpdate()
    {
        playerRB.velocity = transform.forward * fowardSpeed;

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
}
