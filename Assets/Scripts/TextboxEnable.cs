using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextboxEnable : MonoBehaviour
{
    public TMP_Text alienText;
    void Update()
    {
        if (alienText.text == "")
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
        else
        {
            GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
