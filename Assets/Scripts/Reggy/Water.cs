using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public GameObject alien;

    //public Material sprite;
    private void OnTriggerEnter(Collider other)
    {
        //if any object with the tag Objective2 enters the trigger, the quest on the selected object gets completed
        if (other.gameObject.tag == "ObjectiveWater")
        {
            Destroy(other.gameObject);
            //alien.GetComponent<MeshRenderer>().material = sprite;

            if (alien.GetComponent<ReggyQuest2>())
            {
                alien.GetComponent<ReggyQuest2>().CompleteQuest();
            }
        }
    }
}
