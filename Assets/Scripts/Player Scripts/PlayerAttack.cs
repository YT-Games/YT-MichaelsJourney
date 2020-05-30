using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private WeaponManager weaponManager;

    public float fireRate = 15f;
    private float nextTimeToFire;
    public float damage = 20f;

    private void Awake()
    {
        weaponManager = GetComponent<WeaponManager>();    
    }

    void Start()
    {
        
    }

    void Update()
    {
        WeaponShoot();
    }

    void WeaponShoot()
    {
        // Assualt Rifle
        if (weaponManager.GetCurrentSelectedWeapon().fireType == WeaponFireType.MULTIPLE)
        {
            if (Input.GetMouseButton(0) && Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;

                weaponManager.GetCurrentSelectedWeapon().ShootAnimation();
            }
        }
        //Weapons that shoots SINGLE
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Handle Axe
                if (weaponManager.GetCurrentSelectedWeapon().tag == Tags.AXE_TAG)
                {
                    weaponManager.GetCurrentSelectedWeapon().ShootAnimation();
                }

                //Handle shoot
                if (weaponManager.GetCurrentSelectedWeapon().bulletType == WeaponBulletType.BULLET)
                {
                    weaponManager.GetCurrentSelectedWeapon().ShootAnimation();

                    //BulletFired();
                }
                //Arrow or Spear
                else
                {

                }
            }
        }
    }
}










