using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletShell;
    public GameObject muzzleFlash;

    public bool canAutoFire;
    public float fireRate;
    public float fireCounter;

    public int currentAmmo;
    public int pickupAmount;

    public Transform firePoint;
    public Transform firePoint2;

    public string gunName;
    
    void Update()
    {
        if (fireCounter > 0)
        {
            fireCounter -= Time.deltaTime;
        }
    }

    public void GetAmmo()
    {
        currentAmmo += pickupAmount;
        UIController.instance.ammoText.text = "" + currentAmmo;
    }
}
