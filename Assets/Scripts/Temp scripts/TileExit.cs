using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileExit : MonoBehaviour {
    private AddWallSection[] allWalls;
    public GameObject obst;
    public List<GameObject> obsticles = new List<GameObject>();

    public float spawnCounter;

    // Use this for initialization
    void Start () {
       allWalls = FindObjectsOfType<AddWallSection>();
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
            spawnCounter++;
            if (spawnCounter % 5 == 0)
            {
                float spawnpoint = 0.0f;
                foreach (var item in allWalls)
                {
                    item.zDistance += 2.5f;
                    spawnpoint = item.zDistance;
                }
                Vector3 pos = new Vector3(transform.position.x, transform.position.y, spawnpoint);
                GameObject block = Instantiate(obst, pos, transform.rotation);
                block.transform.Rotate(0, Random.Range(0, 2) * 180, Random.Range(0,4)*90,Space.Self);
            }
            else
            {
                foreach (var item in allWalls)
                {
                    item.RemoveOldTile();
                    item.SpawnNextTile();
                }
            }
        }
    }
}
