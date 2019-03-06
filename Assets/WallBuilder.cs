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

    public float sectionSize;
    // Use this for initialization
    void Start () {
        completeWall = new GameObject("compleateWall");
        completeWall.transform.position = new Vector3(0,0,0);
        BuildRandomWall();
    }
	void AddWallSection(List<GameObject> wallList)
    {
        GameObject randomWallSection = wallList[Random.Range(0, wallList.Count)];
        Vector3 pos = completeWall.transform.position + new Vector3(0,0,zDistance);
        Instantiate(randomWallSection, pos, Quaternion.identity, completeWall.transform);
    }
	
    void BuildRandomWall()
    {
        float wallSize = 20.0f;
        while(wallSize > 0)
        {
            int randNum = Random.Range(0, 4);

            switch (randNum)
            {
                case 0:
                    
                    AddWallSection(walls25list);
                    zDistance += 2.5f;
                    wallSize -= 2.5f;
                    break;
                case 1:
                    if (wallSize >= 5.0)
                    {
                        AddWallSection(walls50list);

                        zDistance += 5.0f;
                        wallSize -= 5.0f;
                    }
                    break;
                case 2:
                    if (wallSize >= 7.5f)
                    {
                        AddWallSection(walls75list);

                        zDistance += 7.5f;
                        wallSize -= 7.5f;
                    }
                    break;
                case 3:
                    if(wallSize >= 10.0f)
                    {
                        AddWallSection(walls10list);
                        zDistance += 10.0f;
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
