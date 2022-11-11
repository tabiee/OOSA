using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interactable : MonoBehaviour
{
    [Header("Text Settings")]
    public TMP_Text textBox;
    public TemplateText templateText;
    public TemplateText completionText;

    private int panelLines;
    private bool questAccepted = false;
    private bool questCompleted = false;

    [Header("Audio Settings")]
    public AudioSource randomSound;
    public AudioClip[] audioSources;
    private void Awake()
    {
        panelLines = templateText.lineAmount;
    }
    public void CompleteQuest()
    {
        questCompleted = true;
    }
    public void Repeater()
    {
        InvokeRepeating("Randomizer", 0.0f, 6.0f);
    }
    void Randomizer()
    {
        randomSound.clip = audioSources[Random.Range(0, audioSources.Length)];
        randomSound.Play();
    }
    public void Interact()
    {
        //if the quest is done, change the text
        if (questCompleted == true)
        {
            templateText = completionText;
        }
        Invoke("Randomizer", 0);
        panelLines = Mathf.Clamp(panelLines, 0, 5);

        //for testing purposes
        //gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        //Debug.Log(panelLines + " amount of lines");

        //if there's lines left, do next panel
        if (panelLines > 0 || questAccepted == true)
        {
            //if no text, do panel1
            if (textBox.text == "")
            {
                textBox.text = templateText.panel1;
                panelLines--;
            }
            //if panel 1, do panel2
            else if (textBox.text == templateText.panel1)
            {
                textBox.text = templateText.panel2;
                panelLines--;
            }
            //if panel 2, do panel3
            else if (textBox.text == templateText.panel2)
            {
                textBox.text = templateText.panel3;
                panelLines--;
            }
            //if panel 3, do panel4
            else if (textBox.text == templateText.panel3)
            {
                textBox.text = templateText.panel4;
                panelLines--;
            }
            //if panel 4, do panel5
            else if (textBox.text == templateText.panel4)
            {
                textBox.text = templateText.panel5;
                panelLines--;
            }
            //if panel 5, do no text
            else
            {
                textBox.text = "";
            }
        }
        //if out of text, give quest
        else
        {
            if (questAccepted == false)
            {
                questAccepted = true;
                textBox.text = "";
                //GetComponent<Quest>().Accept();
            }
        }

    }
}
