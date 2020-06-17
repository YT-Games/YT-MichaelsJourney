using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    void Start()
    {
        index = 0;
        StartCoroutine(Type());
        continueButton.SetActive(false);
        TutorialTextImage.SetActive(false);
        tutorialIndex = 0;
        tutorialIsOn = false;
        continueButtonIsOn = false;
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
            tutorialMessage.text = "press LEFT MOUSE BUTTON to attack/shot";
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                tutorialIndex++;
            }
        }
        else if (tutorialIndex == 9)
        {
            tutorialMessage.text = "press RIGHT MOUSE BUTTON to aim";
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                tutorialIndex++;
                tutorialMessage.text = "";
                tutorialIsOn = false;
            }
        }
    }
}
