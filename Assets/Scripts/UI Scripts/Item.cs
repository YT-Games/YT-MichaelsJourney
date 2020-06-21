using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int ID;
    public string type;
    public string description;
    public Sprite icon;
    public bool pickedUp;

    private GameObject player;

    private void Awake()
    {
        player = GameObject.Find("/Player");
    }

    public void ItemUsage()
    {
        // health item
        if (type == "Fruit")
        {
            Debug.Log("Eat Fruit and resture 10hp");
            player.GetComponent<HealthScript>().RestoreHealth(10f);
        }
    }

}
