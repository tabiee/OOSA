using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 1200;
    public float timeHalf = 600;
    public float percCooldown = 6.0f;

    public GameObject audioLocation;
    public TMP_Text timeText;
    public TMP_Text warningText;

    public bool timerIsRunning = false;
    public bool repeatActive = false;

    private int percentage = 100;
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
                SceneManager.LoadScene("badEnd");
            }
        }
        if (timeRemaining <= timeHalf && repeatActive == false)
        {
            audioLocation.GetComponent<Randomize>().Repeater();
            warningText.text = "WARNING: \n Suffocation imminent";
            repeatActive = true;
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
