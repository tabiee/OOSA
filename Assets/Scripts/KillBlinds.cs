using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBlinds : MonoBehaviour
{
    public GameObject triggeredObject;
    public GameObject alien;
    public bool playerNearby = false;
    public bool sendToMoon = false;
    private void Update()
    {
        if (playerNearby == true && Input.GetKeyDown(KeyCode.E))
        {
            sendToMoon = true;
        }
        if (sendToMoon == true)
        {
            triggeredObject.transform.Translate(0, 0.03f, 0);
            Invoke("DestroyIt", 2);
        }
    }
    public void DestroyIt()
    {
        Destroy(triggeredObject);
        alien.GetComponent<HarryQuest1>().CompleteQuest();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && alien.GetComponent<HarryQuest1>())
        {
            playerNearby = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && alien.GetComponent<HarryQuest1>())
        {
            playerNearby = false;
        }
    }
}
