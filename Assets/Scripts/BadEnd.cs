using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BadEnd : MonoBehaviour
{
    //idk why this didnt work
    /*public Button booton;
      public void Start()
    {
        booton.onClick.AddListener(ClickEvent);
    }

    public void ClickEvent()
    {
        if (booton.name == "tryagain")
        {
            SceneManager.LoadScene("map1");
        }
        else
        {
            SceneManager.LoadScene("main menu");
        }
    }*/
    public void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void TryAgain()
    {
        SceneManager.LoadScene("map1");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("main menu");
    }
}
