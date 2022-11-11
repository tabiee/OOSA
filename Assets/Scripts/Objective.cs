using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    public GameObject alien;
    private void OnTriggerEnter(Collider other)
    {
        //if any object with the tag Objective enters the trigger, the quest on the selected object gets completed
        if (other.gameObject.tag == "Objective")
        {
            alien.GetComponent<Interactable>().CompleteQuest();
        }
    }
}
