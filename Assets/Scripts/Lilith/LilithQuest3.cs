using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LilithQuest3 : MonoBehaviour
{
    // this is the gravity quest wip
    [Header("Text Settings")]
    public TMP_Text textBox;
    public TemplateText templateText;
    public TemplateText completionText;
    //public GameObject[] explode;

    public int panelLines;
    public bool questAccepted = false;
    public bool questCompleted = false;

    [Header("Audio Settings")]
    public AudioSource randomSound;
    public AudioClip[] audioSources;
    private void Awake()
    {
        textBox = GetComponentInChildren<TMP_Text>();
        //explode = GameObject.FindGameObjectsWithTag("explodetrigger");


        var loadTemplateText = Resources.Load<TemplateText>("ScriptableObjects/LilShit3");
        var loadCompletionText = Resources.Load<TemplateText>("ScriptableObjects/LilShit3Done");

        randomSound = GetComponentInChildren<AudioSource>();
        var loadAudioSources = Resources.LoadAll<AudioClip>("Audio/Lilith/");

        templateText = loadTemplateText;
        completionText = loadCompletionText;
        audioSources = loadAudioSources;

        panelLines = templateText.lineAmount;

        Debug.Log("LilithQuest3 was added!");
    }
    public void CompleteQuest()
    {
        //if the quest is done, change the text
        Debug.Log("LilithQuest3 was completed!");
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
        randomSound.volume = 0.2f;
        randomSound.clip = audioSources[Random.Range(0, audioSources.Length)];
        randomSound.Play();
    }
    public void Interact()
    {
        Debug.Log("LilithQuest3 was interacted with!");
        Invoke("Randomizer", 0);
        panelLines = Mathf.Clamp(panelLines, 0, 5);

        //for testing purposes
        //gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        Debug.Log("LilithQuest3 - Line amount is: " + panelLines);

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
        //if out of text, give quest. if quest done, do win ending
        else
        {
            if (questAccepted == false && questCompleted == false)
            {
                //explode.gameObject.SetActive(true);
                //GameObject.Find("explodetrigger").SetActive(true);
                Debug.Log("LilithQuest3 was accepted!");
                questAccepted = true;
                textBox.text = "";
                //GetComponent<Quest>().Accept();
            }
            else
            {
                Debug.Log("LilithQuest3 ending actived!");
                //SceneManager.LoadScene("GoodEnd");
            }
        }
    }
}
