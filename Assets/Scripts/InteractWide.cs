using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWide : MonoBehaviour
{
    public bool inRange = false;
    public GameObject triggeredObject;
    private void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            triggeredObject.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false;
        }
    }


}
