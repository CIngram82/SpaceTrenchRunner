using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileExit : MonoBehaviour {
    private TileController tc;
    // Use this for initialization
    void Start () {
       tc =  GameObject.Find("TileController").GetComponent<TileController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    // after update to building walls this will be moved to a single exit
    // that exit will just move ahead every time the player hits it.
    // respawning a new section every time. 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            tc.RemoveOldTile();
            tc.SpawnNextTile();
        }
    }
}
