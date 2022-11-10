using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuText : MonoBehaviour
{
    public TMP_Text text;
    public void OnMouseDown()
    {
        SceneManager.LoadScene("SampleScene");
    }
    private void OnMouseEnter()
    {
        text.GetComponent<TextMeshProUGUI>().color = new Color32(0, 191, 255, 255);
    }
    private void OnMouseExit()
    {
        text.GetComponent<TextMeshProUGUI>().color = new Color32(255, 255, 255, 255);
    }
}
