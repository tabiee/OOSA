using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityButton : MonoBehaviour


{
    public GameObject triggeredObject;
    public bool gravitySwitchNo;
    public bool gravitySwitchSpicy;
    public GameObject gravityButtNo;
    public GameObject gravityButtSpicy;
    


    private void Update()
    {
        GameObject Player = GameObject.Find("Player");
        Gravity painovoima = Player.GetComponent<Gravity>();

        if (gravitySwitchNo && gravitySwitchSpicy == true)
        { 
            painovoima.gravityValue = -10;
        }


        if (Input.GetKeyDown(KeyCode.Q))
        {
            
            gravitySwitchNo = !gravitySwitchNo;

            if (gravitySwitchNo)
            {
                gravityButtNo.GetComponent<Renderer>().material.color = Color.green;
                painovoima.gravityValue += 10;
            }
            else if (!gravitySwitchNo)
            {
                gravityButtNo.GetComponent<Renderer>().material.color = Color.red;
                painovoima.gravityValue = -10; 
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
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

    }
}





        
