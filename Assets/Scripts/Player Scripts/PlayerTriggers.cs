using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class PlayerTriggers : MonoBehaviour
{

    public GameObject dialogManager;

    public GameObject dialogWithKneski;
    public GameObject dialogWithKneski2;
    public GameObject dialogWithKneski3;

    [HideInInspector]
    public int convNumber = 1; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Kneski" && dialogManager.GetComponent<DialogStartGamePlay>().endConWithKneski == false && convNumber == 1)
        {
            this.GetComponent<PlayerMovement>().enabled = false;
            this.GetComponentInChildren<MouseLook>().enabled = false;
            this.GetComponentInChildren<PlayerFootsteps>().enabled = false;

            dialogWithKneski.SetActive(true);
            dialogManager.GetComponent<DialogStartGamePlay>().TutorialTextImage.SetActive(false);
            dialogManager.GetComponent<DialogStartGamePlay>().tutorialMessage.text = "";
            dialogManager.SetActive(false);
        }
        else if (other.tag == "Kneski" && dialogManager.GetComponent<DialogStartGamePlay>().endConWithKneski == false && convNumber == 2)
        {
            this.GetComponent<PlayerMovement>().enabled = false;
            this.GetComponentInChildren<MouseLook>().enabled = false;
            this.GetComponentInChildren<PlayerFootsteps>().enabled = false;

            dialogWithKneski2.SetActive(true);
            dialogManager.GetComponent<DialogStartGamePlay>().TutorialTextImage.SetActive(false);
            dialogManager.GetComponent<DialogStartGamePlay>().tutorialMessage.text = "";
            dialogManager.SetActive(false);
        }
        else if (other.tag == "Kneski" && dialogManager.GetComponent<DialogStartGamePlay>().endConWithKneski == false && convNumber == 3)
        {
            this.GetComponent<PlayerMovement>().enabled = false;
            this.GetComponentInChildren<MouseLook>().enabled = false;
            this.GetComponentInChildren<PlayerFootsteps>().enabled = false;

            dialogWithKneski3.SetActive(true);
            dialogManager.GetComponent<DialogStartGamePlay>().TutorialTextImage.SetActive(false);
            dialogManager.GetComponent<DialogStartGamePlay>().tutorialMessage.text = "";
            dialogManager.SetActive(false);
        }

    }



}
