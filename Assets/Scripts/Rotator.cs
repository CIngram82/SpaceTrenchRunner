using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {
    public float zRotation;
    public AddWallSection aWallSec;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update () {
        if(aWallSec.zDistance % 250 == 0)
        {
            zRotation = Mathf.Lerp(-10, 10, Mathf.PingPong(Time.time, 1)); 
        }
        Rotation();
    }

    void Rotation()
    {
        transform.Rotate(new Vector3(0, 0, zRotation) * Time.deltaTime);
    }
}
