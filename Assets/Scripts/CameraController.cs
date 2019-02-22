using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    private Transform playerTransform;
    private Vector3 cameraOffset;
	// Use this for initialization
	void Start () {
        playerTransform = GameObject.Find("Player").transform;
        cameraOffset = transform.position - playerTransform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = playerTransform.position + cameraOffset;
	}
    
}
