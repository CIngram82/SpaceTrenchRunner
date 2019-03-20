using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour {
    public GameObject projectilePrefab;
    public Transform firePoint01;
    public Transform firePoint02;


    private int firePointNumber = 1;
    public float projectileSpeed = 50;
    public float maxAmmo = 100;
    public float currentAmmo;
    public float rechargeRate = 5; // Per second 
    public float attackCost = 10;

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

	}

   public void FireWeapon(float playerSpeed)
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
        
        projectile.GetComponent<ProjectileMovement>().speed = playerSpeed + projectileSpeed; 
    }
   public void WeaponBoost(float boostAmount)
    {
        currentAmmo += boostAmount;

    }
}
