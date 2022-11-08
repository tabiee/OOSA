using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [Range(-20, 10)] public int gravityValue = -10;

    void Update()
    {
        Physics.gravity = new Vector3(0, gravityValue, 0);

        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            gravityValue++;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            gravityValue--;
        }
    }
}
