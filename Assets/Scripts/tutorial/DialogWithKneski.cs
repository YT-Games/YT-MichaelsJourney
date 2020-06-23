using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DialogWithKneski : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject continueButton;
    private bool continueButtonIsOn;
    public GameObject kneskiTextImage;
    public GameObject dialogManager;


    private void Start()
    {
        index = 10;
        StartCoroutine(Type());
        continueButton.SetActive(false);
        kneskiTextImage.SetActive(true);
        continueButtonIsOn = false;
    }

    private void Update()
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
                kneskiTextImage.SetActive(false);
                dialogManager.SetActive(true);
                textDisplay.text = "";
                dialogManager.GetComponent<DialogStartGamePlay>().TutorialTextImage.SetActive(false);
                dialogManager.GetComponent<DialogStartGamePlay>().endConWithKneski = true;
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
}
