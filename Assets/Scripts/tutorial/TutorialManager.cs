using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public Text tutorialMessage;
    public GameObject player;
    private int tutorialIndex;

    void Start()
    {
        tutorialMessage.text = "";
        tutorialIndex = 0;
    }

    void Update()
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
            tutorialMessage.text = "press A to move Left";
            if (Input.GetKeyDown(KeyCode.A))
            {
                tutorialIndex++;
            }
        }
        else if (tutorialIndex == 2)
        {
            tutorialMessage.text = "press D to move Right";
            if (Input.GetKeyDown(KeyCode.D))
            {
                tutorialIndex++;
            }
        }
        else if (tutorialIndex == 3)
        {
            tutorialMessage.text = "press S to move Back";
            if (Input.GetKeyDown(KeyCode.S))
            {
                tutorialIndex++;
            }
        }
        else if (tutorialIndex == 4)
        {
            tutorialMessage.text = "press SPACE to Jump";
            if(Input.GetKeyDown(KeyCode.Space))
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
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                tutorialIndex++;
            }
        }
        else if (tutorialIndex == 8)
        {
            tutorialMessage.text = "press left Mouse button to attack";
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                tutorialIndex++;
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
