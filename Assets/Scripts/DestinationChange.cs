using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationChange : MonoBehaviour
{
    public int xPos;
    public int zPos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Animal")
        {
            Debug.Log("Colide!!");
            xPos = Random.Range(160, 240);
            zPos = Random.Range(1760, 2800);
            this.gameObject.transform.position = new Vector3(xPos, 0, zPos);
        }
    }
}
