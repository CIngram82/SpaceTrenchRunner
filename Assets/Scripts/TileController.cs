using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour {
    public  List<GameObject> strightTileList = new List<GameObject>();
    public  List<GameObject> rightTileList   = new List<GameObject>();
    public  List<GameObject> leftTileList    = new List<GameObject>();
    private List<GameObject> activeTileList  = new List<GameObject>();
    private Transform spawnPoint;
     

    void Start () {
        spawnPoint = GetComponent<Transform>();
		for(int i =0; i < 10; i++)
        {
            SpawnTile(strightTileList);
        }
      
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SpawnNextTile()
    {

            SpawnTile(strightTileList);
        
    }
    

    public void SpawnTile(List<GameObject> tileList)
    {
        GameObject randomTile = tileList[Random.Range(0, tileList.Count)];
        randomTile = Instantiate(randomTile, spawnPoint.transform.position, spawnPoint.rotation, transform);
        spawnPoint = randomTile.transform.Find("EndPoint");
        // Set spawnpoint to the endpoint of the tile just created in game
        activeTileList.Add(randomTile);
    }

    public void RemoveOldTile()
    {
        GameObject tileToRemove = activeTileList[0];
        activeTileList.Remove(tileToRemove);
        Destroy(tileToRemove);
    }

    
}
