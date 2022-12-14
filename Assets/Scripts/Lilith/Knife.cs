using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public GameObject alien;
    public GameObject knife;
    //public Material sprite;
    private void OnTriggerEnter(Collider other)
    {
        //if any object with the tag Objective2 enters the trigger, the quest on the selected object gets completed
        if (other.gameObject.tag == "ObjectiveKnife")
        {
            Destroy(other.gameObject);
            //alien.GetComponent<MeshRenderer>().material = sprite;

            if (alien.GetComponent<LilithQuest1>())
            {
                alien.GetComponent<LilithQuest1>().CompleteQuest();
                knife.gameObject.SetActive(true);
            }
        }
    }
}
