using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundaries : MonoBehaviour
{
    public GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit ...");
        if (other.tag == "Boundaries")
        {
            Debug.Log("hit boundaries");
        }
    }
}
