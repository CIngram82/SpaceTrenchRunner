using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBuilder : MonoBehaviour {
    public List<GameObject> walls25list = new List<GameObject>();
    public List<GameObject> walls50list = new List<GameObject>();
    public List<GameObject> walls75list = new List<GameObject>();
    public List<GameObject> walls10list = new List<GameObject>();
    private float zDistance = 0;
    private GameObject completeWall;
    public GameObject sideA;
    public GameObject sideB;
    public GameObject sideC;
    public GameObject sideD;

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
            int randNum = Random.Range(0, 4);

            switch (randNum)
            {
                case 0:
                    zDistance += 1.25f;
                    AddWallSection(walls25list, side);
                    zDistance += 1.25f;
                    wallSize -= 2.5f;
                    break;
                case 1:
                    if (wallSize >= 5.0)
                    {
                        zDistance += 2.5f;
                        AddWallSection(walls50list, side);
                        zDistance += 2.5f;
                        wallSize -= 5.0f;
                    }
                    break;
                case 2:
                    if (wallSize >= 7.5f)
                    {
                        zDistance += 3.75f;
                        AddWallSection(walls75list,side);
                        zDistance += 3.75f;
                        wallSize -= 7.5f;
                    }
                    break;
                case 3:
                    if(wallSize >= 10.0f)
                    {
                        zDistance += 5.0f;
                        AddWallSection(walls10list,side);
                        zDistance += 5.0f;
                        wallSize -= 10.0f;
                    }
                    break;
                default:
                    wallSize -= 2.5f;
                    Debug.Log("error");
                    break;
            }
           
        }
    }
}
