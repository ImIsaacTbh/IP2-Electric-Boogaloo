using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FPSController : MonoBehaviour
{
    public Camera playerCamera;
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float jumpPower = 7f;
    public float gravity = 10f;
    public float lookSpeed = 2f;
    public float lookXLimit = 45f;
    public Transform groundCheck;
    public float groundCheckDistance = 0.4f; // Distance to check for ground
    public LayerMask groundMask; // Layer mask for ground
    public float maxFallSpeed = 20f; // Maximum fall speed

    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;
    public bool canMove = true;
    public bool useGravity = true; // New flag to toggle gravity
    CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }



    private void Update()
    {
        if (PauseMenu.instance.isPaused == false)
        {

            
          
                #region Handles Movement
                Vector3 forward = transform.TransformDirection(Vector3.forward);
                Vector3 right = transform.TransformDirection(Vector3.right);

                bool isRunning = Input.GetKey(KeyCode.LeftShift);
                float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
                float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
                float movementDirectionY = moveDirection.y;

                moveDirection = (forward * curSpeedX) + (right * curSpeedY);
                #endregion

                #region Handles Jumping
                if (IsGrounded() && Input.GetButton("Jump") && canMove)
                {
                    moveDirection.y = jumpPower;
                }
                else
                {
                    moveDirection.y = movementDirectionY;
                }

                if (!IsGrounded())
                {
                    if (useGravity)
                    {
                        moveDirection.y -= gravity * Time.deltaTime;
                        moveDirection.y = Mathf.Max(moveDirection.y, -maxFallSpeed); // Limit fall speed
                    }
                }
                #endregion

                #region Handles Rotation
                characterController.Move(moveDirection * Time.deltaTime);

                if (canMove)
                {
                    rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
                    rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
                    playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
                    transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
                }
                #endregion
            }


            bool IsGrounded()
            {
                return Physics.CheckSphere(groundCheck.position, groundCheckDistance, groundMask);
            }
        }
}