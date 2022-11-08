using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFacing : MonoBehaviour
{
    public bool playerNearby;
    public Transform playerTarget;
    public GameObject turningObject;
    void Update()
    {
        Debug.Log(playerNearby);
        if (playerNearby == true)
        {
            //cheap but instant turns
            //turningObject.transform.LookAt(playerTarget);

            //smooth rotation
            var targetRotation = Quaternion.LookRotation(playerTarget.transform.position - transform.position);
            turningObject.transform.rotation = Quaternion.Lerp(turningObject.transform.rotation, targetRotation, 3.0f * Time.deltaTime);
        }
        else
        {
            //cheap but instant turns
            //turningObject.transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);

            //smooth rotation
            turningObject.transform.rotation = Quaternion.Lerp(turningObject.transform.rotation, transform.rotation, 3.0f * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerNearby = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerNearby = false;
        }
    }
}
