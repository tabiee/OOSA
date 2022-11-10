using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SoundInteractable : MonoBehaviour
{
    public TMP_Text textBox;
    public TemplateText templateText;
    public AudioSource soundClip;
    public float useCooldown = 1.5f;

    private float useAllowed = 0.0f;
    public void Interact()
    {
        if (Time.time > useAllowed)
        {
            //trigger cd
            useAllowed = Time.time + useCooldown;

            gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            soundClip.Play();

            // if no text, do panel1
            if (textBox.text == "")
            {
                textBox.text = templateText.panel1;
            }
            //if panel 1, do panel2
            else if (textBox.text == templateText.panel1)
            {
                textBox.text = templateText.panel2;
            }
            //if panel 2, do panel3
            else if (textBox.text == templateText.panel2)
            {
                textBox.text = templateText.panel3;
            }
            //if panel 3, do panel4
            else if (textBox.text == templateText.panel3)
            {
                textBox.text = templateText.panel4;
            }
            //if panel 4, do panel5
            else if (textBox.text == templateText.panel4)
            {
                textBox.text = templateText.panel5;
            }
            //if panel 5, do no text
            else
            {
                textBox.text = "";
            }
        }
    }
}
