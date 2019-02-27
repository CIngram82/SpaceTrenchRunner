using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossHairConrtoller : MonoBehaviour {
    private Camera FPVcam;
    public GameObject plasmaBoltPreFab;
    public Transform weaponPoint01;
    public Transform weaponPoint02;
    // Use this for initialization
    void Start ()
    {
        FPVcam = FindObjectOfType<Camera>();
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        UpdateCrossHairPos();
        if (Input.GetMouseButtonDown(0))
        {
            FireLaser();
        }

    }

    void UpdateCrossHairPos()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;

        Vector2 newPos = new Vector2(mouseX, mouseY);
        gameObject.transform.position = newPos;
    }

    void FireLaser()
    {
        print("Pew!");
        Ray ray;
        RaycastHit hit;
        ray = FPVcam.ScreenPointToRay(Input.mousePosition);

       

    }

}
