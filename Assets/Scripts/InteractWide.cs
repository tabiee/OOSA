using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractWide : MonoBehaviour
{
    public TemplateText templateText;
    public GameObject triggeredObject;
    public TMP_Text textBox;
    private void Update()
    {
        if (templateText.inRange && Input.GetKeyDown(KeyCode.E))
        {
            triggeredObject.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

            if (textBox.text == "Trigger")
            {
                textBox.text = "Wide";
            }
            else
            {
                textBox.text = "Trigger";
            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            templateText.inRange = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            templateText.inRange = false;
        }
    }


}
