using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddWallSection : MonoBehaviour {
    public List<GameObject> walls = new List<GameObject>();
    private List<GameObject> activeTileList = new List<GameObject>();

    private float zDistance = 0;
    public float sectionSize = 50.0f;
    // Use this for initialization
    void Start () {
        BuildRandomWall(sectionSize);
    }
	public void SpawnNextTile()
    {
        AddWallSections(walls);
    }

     void AddWallSections(List<GameObject> wallList)
    {
        zDistance += 2.5f;
        GameObject randomWallSection = wallList[Random.Range(0, wallList.Count)];
        Vector3 pos = transform.position + new Vector3(0, 0, zDistance);
        GameObject randomTile = Instantiate(randomWallSection, pos, transform.rotation, transform);
        activeTileList.Add(randomTile);
        int randY = Random.Range(0, 4);
        randomTile.transform.Rotate(0, randY * 90, 0, Space.Self);
    }

    void BuildRandomWall(float size)
    {
        float wallSize = size;
        while (wallSize > 0)
        {

            AddWallSections(walls);
            wallSize -= 2.5f;
        }
    }
    public void RemoveOldTile()
    {
        GameObject tileToRemove = activeTileList[0];
        activeTileList.Remove(tileToRemove);
        Destroy(tileToRemove);
    }
}
