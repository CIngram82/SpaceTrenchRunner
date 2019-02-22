using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour {
    private Vector3 startPoint;
    private Vector3 endPoint;
    private Transform wall1;
    private Transform wall2;
    public GameObject CubeObstacle;
    // Use this for initialization
    void Start () {

        wall1 = gameObject.transform.Find("Wall1").transform;
        startPoint = GetVector3ForWall(wall1);

        wall2 = gameObject.transform.Find("Wall2").transform;
        endPoint = GetVector3ForWall(wall2);

        SpawnCube();
    }
    Vector3 GetVector3ForWall(Transform wall)
    {
        
        Vector3 wallPos = wall.position;
        Vector3 wallScale = wall.localScale;
        float wallx = wallPos.x;
        float wally = Random.Range((float)(wallPos.y - (wallScale.y * .5)), (float)(wallPos.y + (wallScale.y * .5)));
        float wallz = Random.Range((float)(wallPos.z - (wallScale.z * .5)), (float)(wallPos.z + (wallScale.z * .5)));
        return new Vector3(wallx, wally, wallz);
    }
 
	
    void SpawnCube()
    {
        // spawn a cube obstacle prefab and move it the center point between startpoint and end point. alighing it with the direction between the 2
        // and adjusting its size to fill the space between the 2.
        float dist = Vector3.Distance(startPoint, endPoint);
        Vector3 size = new Vector3(0.5f, 0.5f, dist);
        GameObject cubeOb1 = Instantiate(CubeObstacle, transform);
        
        cubeOb1.transform.position = startPoint;
        cubeOb1.transform.localScale = size;
        cubeOb1.transform.LookAt(endPoint);
        cubeOb1.transform.Rotate(0,0,45);
        cubeOb1.transform.position = Vector3.MoveTowards(startPoint, endPoint, (float)(dist * 0.5));
        
    }

}
