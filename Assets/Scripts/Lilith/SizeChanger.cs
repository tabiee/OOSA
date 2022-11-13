using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SizeChanger : MonoBehaviour
{
    public GameObject triggeredObject;
    public Transform player;
    public Transform playerBody;
    public GameObject alien;
    public TMP_Text scaleText;

    public bool playerNearby;

    private Vector3 scaleChange;
    private bool triggerOnce = false;
    private void Awake()
    {
        scaleChange = new Vector3(0.2f, 0.2f, 0.2f);
    }
    void Update()
    {
        if (playerNearby == true && Input.GetKeyDown(KeyCode.E))
        {
            if (triggeredObject.gameObject.name == "sizeUp")
            {
                triggeredObject.GetComponent<Renderer>().material.color = Color.red;
                player.transform.localScale += scaleChange;
                playerBody.transform.position = new Vector3(-8.3813f, 0.8991978f, -3.086281f);
                Invoke("ResetColor", 0.5f);
            }
            else if (triggeredObject.gameObject.name == "sizeDown")
            {
                triggeredObject.GetComponent<Renderer>().material.color = Color.red;
                player.transform.localScale -= scaleChange;
                playerBody.transform.position = new Vector3(-8.3813f, 0.8991978f, -0.05828547f);

                Invoke("ResetColor", 0.5f);
            }
        }
        scaleText.text = "Scale: \n" + player.transform.localScale;

        if (player.transform.localScale.y <= 0.5 && alien.GetComponent<LilithQuest2>() && triggerOnce == false)
        {
            triggerOnce = true;
            alien.GetComponent<LilithQuest2>().CompleteQuest();
        }
    }
    public void ResetColor()
    {
        triggeredObject.GetComponent<Renderer>().material.color = Color.cyan;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }
}
