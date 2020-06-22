using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField]
    private WeaponHandler[] weapons;

    [HideInInspector]
    public Boolean axe, bow, spear, revolver, shotgun, assaultRifle = false;

    private int currentWeaponIndex;

    void Start()
    {
        currentWeaponIndex = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && (axe == true))
        {
            TurnOnSelectedWeapon(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && (bow == true))
        {
            TurnOnSelectedWeapon(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && (spear == true))
        {
            TurnOnSelectedWeapon(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && (revolver == true))
        {
            TurnOnSelectedWeapon(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5) && (shotgun == true))
        {
            TurnOnSelectedWeapon(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6) && (assaultRifle == true))
        {
            TurnOnSelectedWeapon(5);
        }
    }

    public void TurnOnSelectedWeapon(int weaponIndex)
    {
        if (currentWeaponIndex == weaponIndex)
        {
            return;
        }

        weapons[currentWeaponIndex].gameObject.SetActive(false);
        weapons[weaponIndex].gameObject.SetActive(true);

        currentWeaponIndex = weaponIndex;
    }

    public WeaponHandler GetCurrentSelectedWeapon()
    {
        return weapons[currentWeaponIndex];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Axe")
        {
            Destroy(other.gameObject);
            axe = true;
            currentWeaponIndex = 0;
            weapons[currentWeaponIndex].gameObject.SetActive(true);
        }
    }

}
