using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossHairConrtoller : MonoBehaviour {
    // Use this for initialization
    void Start ()
    {
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        UpdateCrossHairPos();
    }

    void UpdateCrossHairPos()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;

        Vector2 newPos = new Vector2(mouseX, mouseY);
        gameObject.transform.position = newPos;
    }
}
