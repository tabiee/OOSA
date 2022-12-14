using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayInteraction : MonoBehaviour
{
    public RaycastHit hitData;
    public LayerMask interactionLayer;
    public LayerMask interactionLayer2;
    public LayerMask interactionLayer3;
    public float pickupRange = 3.5f;
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // show the ray
        Debug.DrawRay(ray.origin, ray.direction * 10);

        // use text button
        if (Physics.Raycast(ray, out hitData, pickupRange, interactionLayer, QueryTriggerInteraction.Ignore))
        {
            GameObject hitObject = hitData.transform.gameObject;

            if (Input.GetKeyDown(KeyCode.E) && hitObject.GetComponent<HarryQuest1>())
            {
                hitObject.GetComponent<HarryQuest1>().Interact();
            }
            else if (Input.GetKeyDown(KeyCode.E) && hitObject.GetComponent<HarryQuest2>())
            {
                hitObject.GetComponent<HarryQuest2>().Interact();
            }
            else if (Input.GetKeyDown(KeyCode.E) && hitObject.GetComponent<HarryQuest3>())
            {
                hitObject.GetComponent<HarryQuest3>().Interact();
            }
            else if (Input.GetKeyDown(KeyCode.E) && hitObject.GetComponent<LilithQuest1>())
            {
                hitObject.GetComponent<LilithQuest1>().Interact();
            }
            else if (Input.GetKeyDown(KeyCode.E) && hitObject.GetComponent<LilithQuest2>())
            {
                hitObject.GetComponent<LilithQuest2>().Interact();
            }
            else if (Input.GetKeyDown(KeyCode.E) && hitObject.GetComponent<LilithQuest3>())
            {
                hitObject.GetComponent<LilithQuest3>().Interact();
            }
            else if (Input.GetKeyDown(KeyCode.E) && hitObject.GetComponent<ReggyQuest1>())
            {
                hitObject.GetComponent<ReggyQuest1>().Interact();
            }
            else if (Input.GetKeyDown(KeyCode.E) && hitObject.GetComponent<ReggyQuest2>())
            {
                hitObject.GetComponent<ReggyQuest2>().Interact();
            }
            else if (Input.GetKeyDown(KeyCode.E) && hitObject.GetComponent<ReggyQuest3>())
            {
                hitObject.GetComponent<ReggyQuest3>().Interact();
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                hitObject.GetComponent<Interactable>().Interact();
            }
        }

        // test the sound button
        else if (Physics.Raycast(ray, out hitData, pickupRange, interactionLayer2, QueryTriggerInteraction.Ignore))
        {

            GameObject hitObject = hitData.transform.gameObject;

            if (Input.GetKeyDown(KeyCode.E))
            {
                hitObject.GetComponent<SoundInteractable>().Interact();
            }
        }
        // test randomizer
        else if (Physics.Raycast(ray, out hitData, pickupRange, interactionLayer3, QueryTriggerInteraction.Ignore))
        {

            GameObject hitObject = hitData.transform.gameObject;

            if (Input.GetKeyDown(KeyCode.E))
            {
                hitObject.GetComponent<Randomize>().PlaySound();
            }
        }
        else
        {

        }
    }
}
