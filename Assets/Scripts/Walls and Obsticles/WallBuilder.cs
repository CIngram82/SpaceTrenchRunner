using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBuilder : MonoBehaviour {
    public List<GameObject> walls = new List<GameObject>();
    public float zDistance = 0;
    private GameObject completeWall;
    public GameObject sideA;
    public GameObject sideB;
    public GameObject sideC;
    public GameObject sideD;
    public GameObject WallPreFab;

    public float sectionSize =20.0f;
    // Use this for initialization
    void Start () {
        completeWall = new GameObject("compleateWall");
        completeWall.transform.position = new Vector3(0,0,0);
        BuildRandomWall(sectionSize, sideA);
        BuildRandomWall(sectionSize, sideB);
        BuildRandomWall(sectionSize, sideC);
        BuildRandomWall(sectionSize, sideD);
    }
	void AddWallSection(List<GameObject> wallList, GameObject side)
    {
        GameObject randomWallSection = wallList[Random.Range(0, wallList.Count)];
        Vector3 pos = side.transform.position + new Vector3(0,0,zDistance);
        Instantiate(randomWallSection, pos, side.transform.rotation, side.transform);
    }
	
    void BuildRandomWall(float size,GameObject side)
    {
        zDistance = 0;
        float wallSize = size;
        while(wallSize > 0)
        {
            zDistance += 1.25f;
            AddWallSection(walls, side);
            zDistance += 1.25f;
            wallSize -= 2.5f;
        }
    }
}
