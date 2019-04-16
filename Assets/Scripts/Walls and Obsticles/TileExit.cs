using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileExit : MonoBehaviour {
    private AddWallSection[] allWalls;
    public GameObject obst;
    public List<GameObject> obsticlesList = new List<GameObject>();
    public int spawnRate = 10;
    public Transform holder;

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
            if (spawnCounter % spawnRate == 0)
            {
                float spawnpoint = 0.0f;
                spawnpoint = allWalls[0].zDistance;
                Vector3 pos = new Vector3(transform.position.x, transform.position.y, spawnpoint);
                GameObject block = Instantiate(obst, pos, transform.rotation,holder);
                GameObject randomObst = obsticlesList[Random.Range(0, obsticlesList.Count)];
                Instantiate(randomObst, pos, transform.rotation, block.transform);
                block.transform.Rotate(0, Random.Range(0, 2) * 180, Random.Range(0,4)*90,Space.Self);
                
                if (spawnCounter % 50 == 0 && spawnRate > 1)
                {
                    spawnRate--;
                }
            }
            foreach (var item in allWalls)
            {
                item.RemoveOldTile();
                item.SpawnNextTile();
            }

        }
    }
}
