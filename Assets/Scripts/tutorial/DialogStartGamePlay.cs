using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class DialogStartGamePlay : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject continueButton;
    private bool continueButtonIsOn;
    public GameObject TutorialTextImage;
    public TextMeshProUGUI tutorialMessage;
    private int tutorialIndex;
    private bool tutorialIsOn;

    public GameObject X;
    public GameObject axe;
    public GameObject appleTree;
    public GameObject boar;
    private GameObject kneski;

    [HideInInspector]
    public Boolean endConWithKneski;

    [HideInInspector]
    public Boolean once;

    private float xHightOffset = 20f;
    public int killBoars;

    private GameObject player;

    void Start()
    {
        index = 0;
        StartCoroutine(Type());
        continueButton.SetActive(false);
        TutorialTextImage.SetActive(false);

        tutorialIndex = 14;
        tutorialIsOn = false;
        continueButtonIsOn = false;

        once = false;

        endConWithKneski = false;

        killBoars = 0;

        player = GameObject.Find("/Player");
        kneski = GameObject.Find("/Kneski");
    }

    void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
            continueButtonIsOn = true;
        }
        if (continueButtonIsOn)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                NextSentence();
            }
        }
        if (tutorialIsOn)
        {
            StartTutorial();
            TutorialTextImage.SetActive(true);
        }
        else
        {
            TutorialTextImage.SetActive(false);
        }
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

    }

    public void NextSentence()
    {
        continueButton.SetActive(false);
        continueButtonIsOn = false;

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            tutorialIsOn = true;
        }
    }

    private void StartTutorial()
    {
        if (tutorialIndex == 0)
        {
            tutorialMessage.text = "press W to move forward";
            if (Input.GetKeyDown(KeyCode.W))
            {
                tutorialIndex++;
            }
        }
        else if (tutorialIndex == 1)
        {
            tutorialMessage.text = "press A to move left";
            if (Input.GetKeyDown(KeyCode.A))
            {
                tutorialIndex++;
            }
        }
        else if (tutorialIndex == 2)
        {
            tutorialMessage.text = "press D to move right";
            if (Input.GetKeyDown(KeyCode.D))
            {
                tutorialIndex++;
            }
        }
        else if (tutorialIndex == 3)
        {
            tutorialMessage.text = "press S to move back";
            if (Input.GetKeyDown(KeyCode.S))
            {
                tutorialIndex++;
            }
        }
        else if (tutorialIndex == 4)
        {
            tutorialMessage.text = "press SPACE to jump";
            if (Input.GetKeyDown(KeyCode.Space))
            {
                tutorialIndex++;
            }
        }
        else if (tutorialIndex == 5)
        {
            tutorialMessage.text = "press LEFT SHIFT to run fast";
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                tutorialIndex++;
            }
        }
        else if (tutorialIndex == 6)
        {
            tutorialMessage.text = "press C to crouch";
            if (Input.GetKeyDown(KeyCode.C))
            {
                tutorialIndex++;
            }
        }
        else if (tutorialIndex == 7)
        {
            tutorialMessage.text = "press 1,2,3,4,5,6 to change weapons";
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                tutorialIndex++;
            }
        }
        else if (tutorialIndex == 8)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && once == false)
            {
                once = true;
                tutorialMessage.text = "Task 1: Completed !!! press T to the next task";

            }
            else if (Input.GetKeyDown(KeyCode.T))
            {
                tutorialIndex = 12;
                once = false;
            }
        }
        else if (tutorialIndex == 9)
        {
            tutorialMessage.text = "press RIGHT MOUSE BUTTON to aim";
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                tutorialIndex++;
            }
        }
        else if (tutorialIndex == 10)
        {
            if (Input.GetKeyDown(KeyCode.I) && once == false)
            {
                once = true;
                tutorialMessage.text = "great !! you collect some apples, you can use them to restore Health. press T to the next task..";
            }
            else if (Input.GetKeyDown(KeyCode.T))
            {
                tutorialIndex = 13;
                once = false;
            }
        }
        else if (tutorialIndex == 11)
        {
            if (player.GetComponent<WeaponManager>().axe == false && once == false)
            {
                Vector3 axePos = new Vector3(axe.transform.position.x,
                                            axe.transform.position.y + xHightOffset,
                                                axe.transform.position.z);
                X.transform.position = axePos;
                X.SetActive(true);
                tutorialMessage.text = "Task 1: find the AXE near the big rock";
                once = true;
            }
            else if (player.GetComponent<WeaponManager>().axe == true)
            {
                X.SetActive(false);
                tutorialMessage.text = "Task 1: Completed !!! now you can use the axe, press LEFT MOUSE to attck";
                tutorialIndex = 8;
                once = false;
            }
        }
        else if (tutorialIndex == 12)
        {
            if (once == false)
            {
                Vector3 appleTreePos = new Vector3(appleTree.transform.position.x,
                                            appleTree.transform.position.y + xHightOffset,
                                                appleTree.transform.position.z);
                X.transform.position = appleTreePos;
                X.SetActive(true);
                tutorialMessage.text = "Task 2: find the APPLE TREE on the side of the road and collect apples";
                once = true;
            }
            else if (appleTree.transform.childCount < 11)
            {
                X.SetActive(false);
                tutorialMessage.text = "Task 2: Completed !!! press I to check your inventory";
                once = false;
                tutorialIndex = 10;
            }
        }
        else if (tutorialIndex == 13)
        {
            Vector3 boarPos = new Vector3(boar.transform.position.x,
                                            boar.transform.position.y + xHightOffset,
                                                boar.transform.position.z);
            X.transform.position = boarPos;
            X.SetActive(true);
            tutorialMessage.text = "Task 3: search for the boar and kill him with the axe !!!";

            if (boar.GetComponent<HealthScript>().is_Dead == true)
            {
                X.SetActive(false);
                tutorialMessage.text = "Task 3: Completed !!! press T to the next task ";
                tutorialIndex++;
            }
        }
        else if (tutorialIndex == 14)
        {
            if (once == false)
            {
                Vector3 kneskiPos = new Vector3(kneski.transform.position.x,
                                            kneski.transform.position.y + xHightOffset,
                                                kneski.transform.position.z);
                X.transform.position = kneskiPos;
                X.SetActive(true);
                tutorialMessage.text = "Task 4: Keep follow the road, maybe we will find someone..";

                once = true;
            }

            if (endConWithKneski == true)
            {
                once = false;
                X.SetActive(false);
                tutorialIndex++;

            }
        }
        else if (tutorialIndex == 15)
        {
            if (once == false)
            {
                player.GetComponent<PlayerMovement>().enabled = true;
                this.GetComponentInChildren<MouseLook>().enabled = true;
                this.GetComponentInChildren<PlayerFootsteps>().enabled = true;

                player.GetComponent<WeaponManager>().bow = true;
                player.GetComponent<WeaponManager>().TurnOnSelectedWeapon(1);
                tutorialMessage.text = "Task 5: kill 10 boars and return to kneski";
                once = true;
            }
            else if (killBoars == 10)
            {
                tutorialMessage.text = "";
                tutorialIsOn = false;
            }
        }
    }
}
