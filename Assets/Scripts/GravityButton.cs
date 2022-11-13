using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityButton : MonoBehaviour
{
    public GameObject triggeredObject;
    public bool playerNearby = false;

    //public bool gravitySwitchNo;
    //public bool gravitySwitchSpicy;
    //public GameObject gravityButtNo;
    //public GameObject gravityButtSpicy;

    private void Update()
    {
        GameObject Player = GameObject.Find("Player");
        Gravity painovoima = Player.GetComponent<Gravity>();

        /*if (gravitySwitchNo && gravitySwitchSpicy == true)
        {
            painovoima.gravityValue = -10;
        }*/


        if (Input.GetKeyDown(KeyCode.E) && playerNearby == true)
        {
            //gravitySwitchNo = !gravitySwitchNo;
            if (triggeredObject.gameObject.name == "gravityButtNo")
            {
                triggeredObject.GetComponent<Renderer>().material.color = Color.green;
                painovoima.gravityValue += 2;
                Invoke("ResetColor", 0.5f);
            }
            else if (triggeredObject.gameObject.name == "gravityButtSpicy")
            {
                triggeredObject.GetComponent<Renderer>().material.color = Color.blue;
                painovoima.gravityValue -= 2;
                Invoke("ResetColor", 0.5f);
            }
        }
        /*
        if (Input.GetKeyDown(KeyCode.E))
        {

            gravitySwitchSpicy = !gravitySwitchSpicy;

            if (gravitySwitchSpicy)
            {
                gravityButtSpicy.GetComponent<Renderer>().material.color = Color.blue;
                painovoima.gravityValue -= 20;
            }
            else if (!gravitySwitchSpicy)
            {
                gravityButtSpicy.GetComponent<Renderer>().material.color = Color.red;
                painovoima.gravityValue = -10;
            }
        }
        */
    }
    public void ResetColor()
    {
        triggeredObject.GetComponent<Renderer>().material.color = Color.red;
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