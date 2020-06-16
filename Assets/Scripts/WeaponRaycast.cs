using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRaycast : MonoBehaviour
{
    public GameObject Weapon;
    private bool isEquiped = false;

    private void Update()
    {
        if(!Weapon.activeSelf && Input.GetKeyDown(KeyCode.Mouse0))
        {
            isEquiped = true;
            Weapon.SetActive(true);
        }else if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            isEquiped = false;
            Weapon.SetActive(false);
        }

        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, fwd, out hit, 10))
        {
            if(hit.collider.tag == "Tree" && Input.GetMouseButtonDown(0) && isEquiped)
            {
                Tree treeScript = hit.collider.GetComponent<Tree>();
                treeScript.treeHealth--;
            }
        }
    }
}
