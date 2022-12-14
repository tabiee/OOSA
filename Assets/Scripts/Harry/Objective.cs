using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    public GameObject alien;
    public Material sprite;
    private void OnTriggerEnter(Collider other)
    {
        //if any object with the tag Objective enters the trigger, the quest on the selected object gets completed
        if (other.gameObject.tag == "Objective")
        {
            Destroy(other.gameObject);
            alien.GetComponent<MeshRenderer>().material = sprite;

            if (alien.GetComponent<HarryQuest2>())
            {
                alien.GetComponent<HarryQuest2>().CompleteQuest();
            }
            else if (alien.GetComponent<Interactable>())
            {
                alien.GetComponent<Interactable>().CompleteQuest();
            }
        }
    }
}
