using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plants : MonoBehaviour
{
    public GameObject alien;
    public int plantAmount = 0;
    public GameObject plant1;
    public GameObject plant2;

    //public Material sprite;
    private void OnTriggerEnter(Collider other)
    {
        //if any object with the tag Objective2 enters the trigger, the quest on the selected object gets completed
        if (other.gameObject.tag == "ObjectivePlant")
        {
            Destroy(other.gameObject);
            //alien.GetComponent<MeshRenderer>().material = sprite;

            if (alien.GetComponent<ReggyQuest1>() && plantAmount != 2)
            {
                plantAmount++;
                if (plant1.gameObject.activeSelf == false && plantAmount >= 1)
                {
                    plant1.gameObject.SetActive(true);
                }
                else if (plant2.gameObject.activeSelf == false && plantAmount >= 2)
                {
                    plant2.gameObject.SetActive(true);
                    alien.GetComponent<ReggyQuest1>().CompleteQuest();
                }
            }
        }
    }
}
