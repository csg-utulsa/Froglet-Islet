/* 
    Author: Jacob Regan
    Data Created: 1/30/21
    Last Modified Data: 2/3/21
    Last Modified By: Jacob Regan
    Description:  PlayerController for movement and player interactions.

 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Transform playerCamera = null;
    [SerializeField] float mouseSensitivity = 3.0f;

    [SerializeField][Range(0.0f, 0.5f)] float moveSmoothTime = 0.3f;
    [SerializeField][Range(0.0f, 0.5f)] float mouseSmoothTime = 0.03f;
    public float walkSpeed = 6.0f;

    public float pushPower = 2.0f;
    [SerializeField] float gravity = -13.0f;

    float cameraPitch = 0f;
    float velocityY = 0.0f;
    CharacterController controller = null;
    private Vector2 currentDir = Vector2.zero;
    private Vector2 currentDirVelocity = Vector2.zero;

    private Vector2 currentMouseDelta = Vector2.zero;
    private Vector2 currentMouseDeltaVelocity = Vector2.zero;

    private Vector3 camPosition;

    private Quaternion camRotation;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerCamera = Camera.main.transform;
        camPosition = playerCamera.localPosition;
        camRotation = playerCamera.localRotation;
        playerCamera.SetParent(gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMouseLook();
        UpdateMovement();
        ApplyGravity();
    }

    void UpdateMouseLook(){
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);
        
        cameraPitch -= currentMouseDelta.y * mouseSensitivity;

        cameraPitch = Mathf.Clamp(cameraPitch, -90f, 30f);

        playerCamera.localEulerAngles = Vector3.right * cameraPitch;

        transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSensitivity);
    }

    void UpdateMovement(){
        Vector2 targetDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        targetDirection.Normalize();

        currentDir = Vector2.SmoothDamp(currentDir, targetDirection, ref currentDirVelocity, moveSmoothTime);

        Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x ) * walkSpeed + Vector3.up * velocityY;

        controller.Move(velocity * Time.deltaTime);
    }

    void ApplyGravity(){
        if(controller.isGrounded){
            velocityY = 0.0f;
        }
        velocityY += gravity * Time.deltaTime;
    }   
}
