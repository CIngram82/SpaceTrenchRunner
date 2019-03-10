using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileExit : MonoBehaviour {
    private AddWallSection[] allWalls;


    // Use this for initialization
    void Start () {
       allWalls = FindObjectsOfType<AddWallSection>();
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
            transform.position = new Vector3(
                transform.position.x,
                transform.position.y,
                transform.position.z + 2.5f);
            foreach (var item in allWalls)
            {
                item.RemoveOldTile();
                item.SpawnNextTile();
            }
        }
    }
}
