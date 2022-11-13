using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HarryQuest1 : MonoBehaviour
{
    // this is the open the blinds quest
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
        textBox = GetComponentInChildren<TMP_Text>();
        var loadTemplateText = Resources.Load<TemplateText>("ScriptableObjects/SirHarry1");
        var loadCompletionText = Resources.Load<TemplateText>("ScriptableObjects/SirHarry1Done");

        randomSound = GetComponentInChildren<AudioSource>();
        var loadAudioSources = Resources.LoadAll<AudioClip>("Audio/Harry/");

        templateText = loadTemplateText;
        completionText = loadCompletionText;
        audioSources = loadAudioSources;

        panelLines = templateText.lineAmount;

        Debug.Log("HarryQuest1 was added!");
    }
    public void CompleteQuest()
    {
        //if the quest is done, change the text
        Debug.Log("HarryQuest1 was completed!");
        templateText = completionText;
        questCompleted = true;
        questAccepted = false;
        panelLines = templateText.lineAmount;
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
        Debug.Log("HarryQuest1 was interacted with!");
        Invoke("Randomizer", 0);
        panelLines = Mathf.Clamp(panelLines, 0, 5);

        //for testing purposes
        //gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        Debug.Log("HarryQuest1 - Line amount is: " + panelLines);

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
        //if out of text, give quest. if quest done, give next quest and remove this one
        else
        {
            if (questAccepted == false && questCompleted == false)
            {
                Debug.Log("HarryQuest1 was accepted!");
                questAccepted = true;
                textBox.text = "";
                //GetComponent<Quest>().Accept();
            }
            else
            {
                textBox.text = "";
                gameObject.AddComponent<HarryQuest2>();
                Destroy(GetComponent<HarryQuest1>());
            }
        }
    }
}
