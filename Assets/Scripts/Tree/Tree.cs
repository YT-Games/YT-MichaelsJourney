using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    GameObject thisTree;
    public int treeHealth = 5;
    private bool isFallen = false;

    private void Start()
    {
        thisTree = transform.parent.gameObject;
    }

    private void Update()
    {
        if(treeHealth <= 0 && !isFallen)
        {
            Rigidbody rb = thisTree.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.useGravity = true;
            rb.AddForce(Vector3.forward, ForceMode.Impulse);
            StartCoroutine(destroyTree()); 
            isFallen = true;
        }
    }

    private IEnumerator destroyTree()
    {
        yield return new WaitForSeconds(5);
        Destroy(thisTree);
    }
}
