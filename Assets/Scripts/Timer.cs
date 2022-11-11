using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    //the actual timer
    public float timeRemaining = 1200;
    public bool timerIsRunning = false;

    public GameObject audioLocation;
    public TMP_Text timeText;
    public TMP_Text warningText;

    public bool repeatActive = false;

    //percentage display
    private int percentage = 100;
    private float percCooldown = 6.0f;
    private float percAllowed = 0.0f;
    private void Start()
    {
        //starts the timer
        timerIsRunning = true;
    }
    void Update()
    {
        timeText.text = "O² " + percentage + "%";

        if (Time.time > percAllowed)
        {
            percAllowed = Time.time + percCooldown;
            percentage -= 1;
        }


        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                //DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time's out!");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
        if (timeRemaining <= 600 && repeatActive == false)
        {
            //audioLocation.GetComponent<Interactable>().Repeater();
            warningText.text = "WARNING: \n Suffocation imminent";
            repeatActive = true;
        }
        if (timeRemaining <= 0)
        {
            SceneManager.LoadScene("badEnd");
        }
    }
    //cool shit but not what i wanted
    /*void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }*/
}
