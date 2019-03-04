using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour {
    public float speed;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 1.5f);
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        rb.velocity = transform.forward * speed;
	}
    private void OnTriggerEnter(Collider other)
    {
        
   
        if (other.gameObject.CompareTag("wall"))
        {
            Destroy(gameObject);
        }

    }

}
