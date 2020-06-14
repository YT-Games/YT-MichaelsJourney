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
    public Text tutorialMessage;
    private int tutorialIndex;
     
    void Start()
    {
        index = 0;
        StartCoroutine(Type());
        continueButton.SetActive(false);

        tutorialMessage.text = "";
        tutorialIndex = -1;

    }

    void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
        if(tutorialIndex >= 0 && tutorialIndex < 10)
        {
            StartTutorial();
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

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            tutorialIndex = 0;
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
                StartTutorial();
            }
        }
        else if (tutorialIndex == 1)
        {
            tutorialMessage.text = "press A to move Left";
            if (Input.GetKeyDown(KeyCode.A))
            {
                tutorialIndex++;
                StartTutorial();
            }
        }
        else if (tutorialIndex == 2)
        {
            tutorialMessage.text = "press D to move Right";
            if (Input.GetKeyDown(KeyCode.D))
            {
                tutorialIndex++;
                StartTutorial();
            }
        }
        else if (tutorialIndex == 3)
        {
            tutorialMessage.text = "press S to move Back";
            if (Input.GetKeyDown(KeyCode.S))
            {
                tutorialIndex++;
                StartTutorial();
            }
        }
        else if (tutorialIndex == 4)
        {
            tutorialMessage.text = "press SPACE to Jump";
            if (Input.GetKeyDown(KeyCode.Space))
            {
                tutorialIndex++;
                StartTutorial();
            }
        }
        else if (tutorialIndex == 5)
        {
            tutorialMessage.text = "press LEFT SHIFT to run fast";
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                tutorialIndex++;
                StartTutorial();
            }
        }
        else if (tutorialIndex == 6)
        {
            tutorialMessage.text = "press C to crouch";
            if (Input.GetKeyDown(KeyCode.C))
            {
                tutorialIndex++;
                StartTutorial();
            }
        }
        else if (tutorialIndex == 7)
        {
            tutorialMessage.text = "press 1,2,3,4,5,6 to change weapons";
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                tutorialIndex++;
                StartTutorial();
            }
        }
        else if (tutorialIndex == 8)
        {
            tutorialMessage.text = "press left Mouse button to attack";
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                tutorialIndex++;
                StartTutorial();
            }
        }
        else if (tutorialIndex == 9)
        {
            tutorialMessage.text = "press right Mouse button to aim";
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                tutorialIndex++;
                tutorialMessage.text = "";
            }
        }
    }
}
