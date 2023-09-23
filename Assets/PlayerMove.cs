using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;
    public Vector3 offset;
    public float jumpForce;
    public float gravityScale;
    public float maxFallSpeed;
    public float Sensitivity;
    public bool candash = false;
    public bool isGrounded=false;
    public CharacterController controller;
    public Camera cameraObj;

    private Vector3 moveDirection;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        isGrounded = controller.isGrounded;
        if (controller.isGrounded)
        {
            
        }
        float h = Input.GetAxis("Mouse X") * Sensitivity;
        transform.Rotate(0, h, 0);

        float v = Input.GetAxis("Mouse Y") * Sensitivity;
        transform.Rotate(-v, 0, 0);
        float maxViewAngle = 65f;
        float minViewAngle = -60f;
        if (transform.rotation.eulerAngles.x > maxViewAngle && transform.rotation.eulerAngles.x < 180.0f)
        {
            transform.rotation = Quaternion.Euler(maxViewAngle, transform.eulerAngles.y, 0.0f);
        }

        if (transform.rotation.eulerAngles.x > 180.0f && transform.rotation.eulerAngles.x < 360f + minViewAngle)
        {
            transform.rotation = Quaternion.Euler(360.0f + minViewAngle, transform.eulerAngles.y, 0.0f);
        }

        float desiredYAngle = transform.eulerAngles.y;
        float desiredXAngle = transform.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
        transform.rotation = rotation;

        //moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);
        float ystore = moveDirection.y;
        moveDirection = (transform.forward * Input.GetAxisRaw("Vertical") * moveSpeed) + (transform.right * Input.GetAxisRaw("Horizontal") * moveSpeed);
        moveDirection = moveDirection.normalized * moveSpeed;
        moveDirection.y = ystore;
        if (controller.isGrounded)
        {
            moveDirection.y = -1;
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }
        else
        {
            if(moveDirection.y>-maxFallSpeed)
            { 
                moveDirection.y -= gravityScale; 
            }
            
        }
        controller.Move(moveDirection * Time.deltaTime);
    }
}
