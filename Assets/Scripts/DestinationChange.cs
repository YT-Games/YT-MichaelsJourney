using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationChange : MonoBehaviour
{
    [SerializeField] int xRange1 = 200;
    [SerializeField] int xRange2 = 240;
    [SerializeField] int zRange1 = 2800;
    [SerializeField] int zRange2 = 2840;

    public int xPos;
    public int zPos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Animal")
        {
            Debug.Log("Colide!!");
            xPos = Random.Range(xRange1, xRange2);
            zPos = Random.Range(zRange1, zRange2);
            this.gameObject.transform.position = new Vector3(xPos, this.transform.position.y, zPos);
        }
    }
}
