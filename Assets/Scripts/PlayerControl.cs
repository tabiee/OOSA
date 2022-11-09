using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Transform cam;
    public Rigidbody rb;
    public GameObject body;
    public Transform feet;
    public LayerMask notGround;

    public float moveSpeed = 4.0f;
    public float turnSpeed = 4.0f;
    public float sprintSpeed = 8.0f;
    public float sprintCooldown = 5.0f;
    public float jumpHeight = 10.0f;
    public int crouchModifier = 2;

    private int crouchSpeed = 1;
    private int sprintDuration = 500;
    private float sprintAllowed = 0.0f;

    private float rotX;
    private float rotY;

    private Vector3 moveInput;
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        cam.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);


        MovePlayer();
        TurnPlayer();
    }
    bool IsGrounded()
    {
        return Physics.CheckSphere(feet.position, 0.25f, ~notGround);
    }
    private void MovePlayer()
    {
        //get input
        moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        sprintDuration = Mathf.Clamp(sprintDuration, 0, 500);

        //if shift is held = run, else = walk, has duration of ~5s, cd of ~3s
        if (Input.GetKey(KeyCode.LeftShift) && sprintDuration > 2 && Time.time > sprintAllowed)
        {
            sprintDuration -= 2;

            Vector3 MoveVector = transform.TransformDirection(moveInput) * sprintSpeed / crouchSpeed;
            rb.velocity = new Vector3(MoveVector.x, rb.velocity.y, MoveVector.z);
        }
        else
        {
            sprintDuration++;

            Vector3 MoveVector = transform.TransformDirection(moveInput) * moveSpeed / crouchSpeed;
            rb.velocity = new Vector3(MoveVector.x, rb.velocity.y, MoveVector.z);
        }

        //sprint cd
        if (sprintDuration <= 2)
        {
            sprintAllowed = Time.time + sprintCooldown;
        }

        //jumping
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }

        //crouching
        if (Input.GetKey(KeyCode.LeftControl))
        {
            body.transform.localScale = new Vector3(1.0f, 0.5f, 1.0f);
            crouchSpeed = crouchModifier;
        }
        else
        {
            body.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            crouchSpeed = 1;
        }
    }
    private void TurnPlayer()
    {
        rotY = Input.GetAxis("Mouse X") * turnSpeed;
        rotX += Input.GetAxis("Mouse Y") * turnSpeed;

        rotX = Mathf.Clamp(rotX, -90f, 90f);

        cam.transform.eulerAngles = new Vector3(-rotX, cam.transform.eulerAngles.y + rotY, 0);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + rotY, 0);
    }
}
