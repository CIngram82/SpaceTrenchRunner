using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsExpForce : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("bump");
            int bumperForce = 10;
            player.GetComponent<Rigidbody>().AddExplosionForce(bumperForce, transform.position, 5, 0, ForceMode.Impulse);
        }
    }
}
