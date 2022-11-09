using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayInteraction : MonoBehaviour
{
    public RaycastHit hitData;
    public LayerMask interactionLayer;
    public LayerMask interactionLayer2;
    public bool didHit = false;
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hitData, 2, interactionLayer, QueryTriggerInteraction.Ignore))
        {
            didHit = true;
            GameObject hitObject = hitData.transform.gameObject;

            if (Input.GetKeyDown(KeyCode.E))
            {
                hitObject.GetComponent<Interactable>().Interact();
            }
        }
        else if (Physics.Raycast(ray, out hitData, 2, interactionLayer2, QueryTriggerInteraction.Ignore))
        {
            didHit = true;
            GameObject hitObject = hitData.transform.gameObject;

            if (Input.GetKeyDown(KeyCode.E))
            {
                hitObject.GetComponent<SoundInteractable>().Interact();
            }
        }
        else
        {
            didHit = false;
        }

        Debug.DrawRay(ray.origin, ray.direction * 10);
    }
}
