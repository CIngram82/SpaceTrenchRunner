﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileExit : MonoBehaviour {
    private TileController tc;
    // Use this for initialization
    void Start () {
       tc =  GameObject.Find("TileController").GetComponent<TileController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            tc.RemoveOldTile();
            tc.SpawnNextTile();
        }
    }
}
