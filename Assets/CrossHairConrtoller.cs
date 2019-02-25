using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossHairConrtoller : MonoBehaviour {
    Vector2 selfPos;
    float crossHairMoveSpeed = 25;
    // Use this for initialization
    void Start () {
        selfPos = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float newX = Screen.width/2;
        float newY = Screen.height/2;
        if (mouseX - crossHairMoveSpeed > selfPos.x)
        {
            newX = mouseX - crossHairMoveSpeed;
        }
        else if (mouseX + crossHairMoveSpeed < selfPos.x)
        {
            newX = mouseX + crossHairMoveSpeed;
        }
        else
        {
            newX = mouseX;
        }

        if (mouseY - crossHairMoveSpeed > selfPos.y)
        {
            newY = mouseY - crossHairMoveSpeed;
        }
        else if (mouseY + crossHairMoveSpeed < selfPos.y)
        {
            newY = mouseY + crossHairMoveSpeed;
        }
        else
        {
            newY = mouseY;
        }

        Vector2 newPos = new Vector2 (newX,newY);
        gameObject.transform.position = newPos;

	}
}
