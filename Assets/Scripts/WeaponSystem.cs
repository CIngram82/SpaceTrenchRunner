using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour {
    public GameObject projectilePrefab;
    public Transform firePoint01;
    public Transform firePoint02;


    private int firePointNumber = 1;
    private float maxAmmo = 100;
    private float currentAmmo ;
    private float rechargeRate = 5; // Per second 
    private float attackCost = 10;

    private UIController uiControl;

    // Use this for initialization
    void Start()
    {
        uiControl = GameObject.Find("UIController").GetComponent<UIController>();
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update () {
        currentAmmo = Mathf.Min(maxAmmo,currentAmmo+ (rechargeRate * Time.deltaTime));
        uiControl.UpdateAmmoDisplay(currentAmmo);
        if (Input.GetMouseButtonDown(0) && (currentAmmo > attackCost))
        {
            
                FireWeapon();
        }	
	}

   void FireWeapon()
    {
        currentAmmo -= attackCost;

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
