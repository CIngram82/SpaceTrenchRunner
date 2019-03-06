using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakupmove : MonoBehaviour {
    private Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        float randFloat = Random.Range(50, 250);
        rb.AddForce(-transform.forward * randFloat);
    }
}
