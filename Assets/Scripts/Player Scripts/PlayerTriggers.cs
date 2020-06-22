using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class PlayerTriggers : MonoBehaviour
{

    public GameObject dialogManager;
    public GameObject dialogWithKneski;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Kneski" && dialogManager.GetComponent<DialogStartGamePlay>().endConWithKneski == false)
        {
            this.GetComponent<PlayerMovement>().enabled = false;
            this.GetComponentInChildren<MouseLook>().enabled = false;
            this.GetComponentInChildren<PlayerFootsteps>().enabled = false;

            dialogWithKneski.SetActive(true);
            dialogManager.GetComponent<DialogStartGamePlay>().TutorialTextImage.SetActive(false);
            dialogManager.GetComponent<DialogStartGamePlay>().tutorialMessage.text = "";
            dialogManager.SetActive(false);
        }
    }



}
