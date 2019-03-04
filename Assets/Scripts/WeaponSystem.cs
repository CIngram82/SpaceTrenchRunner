using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour {
    public GameObject projectilePrefab;
    public Transform firePoint01;
    public Transform firePoint02;
    private int firePointNumber = 1;
	
	// Update is called once per frame
	void Update () {
	if (Input.GetMouseButtonDown(0)){
            FireWeapon();
        }	

	}

   void FireWeapon()
    {
        Transform firePoint;
        if(firePointNumber == 1)
        {
            firePoint = firePoint01;
            firePointNumber = 2;
        }
        else
        {
            firePoint = firePoint02;
            firePointNumber = 1;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        Physics.Raycast(ray, out hitInfo);

        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        projectile.transform.LookAt(hitInfo.point); 
    }
}
