using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talking : MonoBehaviour
{
    public GameObject alien1;
    public GameObject alien2;
    public GameObject alien3;
    public Material sprite;

    public bool triggerOnce;
    void Update()
    {
        if (alien1.gameObject.tag == "talkedTo" && alien2.gameObject.tag == "talkedTo" && triggerOnce == false)
        {
            triggerOnce = true;
            alien3.GetComponent<MeshRenderer>().material = sprite;
            alien3.GetComponent<ReggyQuest3>().CompleteQuest();
        }
    }
}
