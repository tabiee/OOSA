using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interactable : MonoBehaviour
{
    public TMP_Text textBox;
    public TemplateText templateText;
    public void Interact()
    {
        gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

        if (textBox.text == templateText.panel1)
        {
            textBox.text = templateText.panel2;
        }
        else
        {
            textBox.text = templateText.panel1;
        }
    }
}
