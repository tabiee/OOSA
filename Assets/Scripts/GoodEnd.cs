using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoodEnd : MonoBehaviour
{
    public void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    
    public void MainMenu()
    {
        SceneManager.LoadScene("main menu");
    }
}
