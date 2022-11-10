using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    public Transform holdArea;
    public float pickupRange = 3.5f;
    public float pickupForce = 150.0f;
    public float throwForce = 10.0f;

    private GameObject heldObj;
    private Rigidbody heldRB;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObj == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange))
                {
                    //pickup
                    Grab(hit.transform.gameObject);
                }
            }
            else
            {
                //drop
                Drop();
            }
        }
        if (heldObj != null)
        {
            //move
            Move();
        }
    }
    void Move()
    {
        if (Vector3.Distance(heldObj.transform.position, holdArea.position) > 0.1f)
        {
            Vector3 moveDirection = holdArea.position - heldObj.transform.position;
            heldRB.AddForce(moveDirection * pickupForce);
        }
    }
    void Grab(GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>())
        {
            heldRB = pickObj.GetComponent<Rigidbody>();
            heldRB.useGravity = false;
            heldRB.drag = 10;
            heldRB.constraints = RigidbodyConstraints.FreezeRotation;

            heldRB.transform.parent = holdArea;
            heldObj = pickObj;
        }
    }
    void Drop()
    {
        heldRB.useGravity = true;
        heldRB.drag = 1;
        heldRB.constraints = RigidbodyConstraints.None;

        // throw
        heldRB.AddForce(transform.forward * throwForce, ForceMode.Impulse);

        heldRB.transform.parent = null;
        heldObj = null;

    }
}
