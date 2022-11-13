using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeChanger : MonoBehaviour
{
<<<<<<< Updated upstream:Assets/Scripts/SizeChanger.cs
    public bool playerNearby;
=======
    public GameObject triggeredObject;
    public Transform player;
    public Transform playerBody;
    public GameObject alien;
    public TMP_Text scaleText;

    public bool playerNearby;

    private Vector3 scaleChange;
    private bool triggerOnce = false;
    private void Awake()
    {
        scaleChange = new Vector3(0.2f, 0.2f, 0.2f);
    }
>>>>>>> Stashed changes:Assets/Scripts/Lilith/SizeChanger.cs
    void Update()
    {

<<<<<<< Updated upstream:Assets/Scripts/SizeChanger.cs
=======
                Invoke("ResetColor", 0.5f);
            }
        }
        scaleText.text = "Scale: \n" + player.transform.localScale;

        if (player.transform.localScale.y <= 0.5 && alien.GetComponent<LilithQuest2>() && triggerOnce == false)
        {
            triggerOnce = true;
            alien.GetComponent<LilithQuest2>().CompleteQuest();
        }
    }
    public void ResetColor()
    {
        triggeredObject.GetComponent<Renderer>().material.color = Color.cyan;
>>>>>>> Stashed changes:Assets/Scripts/Lilith/SizeChanger.cs
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }

}
