using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float turnSpeed = 4.0f;

    private float minTurnAngle = -90.0f;
    private float maxTurnAngle = 90.0f;
    private float rotX;
    private bool locked = false;

    public Camera cam;
    public CharacterController characterController;
    public float Gravity = 0.1f;
    private float velocity = 0;
    void Update()
    {
        MouseView();
        CamLock();
        Movement();
        //KeyboardMovement();
    }
    void MouseView()
    {
        // get the mouse inputs
        float y = Input.GetAxis("Mouse X") * turnSpeed;
        rotX += Input.GetAxis("Mouse Y") * turnSpeed;
        // clamp the vertical rotation
        rotX = Mathf.Clamp(rotX, minTurnAngle, maxTurnAngle);
        // rotate the camera
        transform.eulerAngles = new Vector3(-rotX, transform.eulerAngles.y + y, 0);
    }
    //this is the first version of movement. requires RigidBody. it doesn't support custom gravity which is why I changed it
    //keeping it here just in case
    /*void KeyboardMovement()
    {
        Vector3 dir = new Vector3(0, 0, 0);
        dir.x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Mouse X") * turnSpeed;
        dir.z = Input.GetAxis("Vertical");
        transform.Translate(dir * moveSpeed * Time.deltaTime);
        transform.eulerAngles = new Vector3(-rotX, transform.eulerAngles.y + y, 0);
    }*/
    void CamLock()
    {
        //press Tab to lock your mouse in place for the tiny Game window. easier for testing & moving the camera
        if (Input.GetKeyDown(KeyCode.Tab) && locked == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            locked = true;
        }
    }
    void Movement()
    {
        // player movement - WASD, uses Character Controller component, cannot have RigidBody
        float horizontal = Input.GetAxis("Horizontal") * moveSpeed;
        float vertical = Input.GetAxis("Vertical") * moveSpeed;
        characterController.Move((cam.transform.right * horizontal + cam.transform.forward * vertical) * Time.deltaTime);

        // Gravity
        if (characterController.isGrounded)
        {
            velocity = 0;
        }
        else
        {
            velocity -= Gravity * Time.deltaTime;
            characterController.Move(new Vector3(0, velocity, 0));
        }
    }
}
