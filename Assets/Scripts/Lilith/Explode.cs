using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Explode : MonoBehaviour
{
    public GameObject alien;
    public bool playerNearby = false;
    private void Update()
    {
        if (playerNearby == true && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("LilshitEnd");
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (alien.GetComponent<LilithQuest3>())
        {
            if (other.CompareTag("Player") && alien.GetComponent<LilithQuest3>().questAccepted == true)
            {
                playerNearby = true;
            }
            else
            {

            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (alien.GetComponent<LilithQuest3>())
        {
            if (other.CompareTag("Player") && alien.GetComponent<LilithQuest3>().questAccepted == true)
            {
                playerNearby = false;
            }
            else
            {
            }
        }
    }
}
