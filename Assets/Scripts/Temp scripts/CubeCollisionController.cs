using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollisionController : MonoBehaviour {
    public GameObject breakUpPrefab;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Destroy(collision.gameObject);
            GameObject go =Instantiate(breakUpPrefab, transform.position,transform.rotation);
            Destroy(go, 1.5f);
            Destroy(gameObject);
        }
    }

}
