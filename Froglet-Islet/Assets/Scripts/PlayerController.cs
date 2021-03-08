/* 
    Author: Jacob Regan
    Data Created: 1/30/21
    Last Modified Data: 2/20/21
    Last Modified By: Jacob Regan
    Description:  PlayerController for movement and player interactions.

 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    Vector3 movement;
    NavMeshAgent agent;

    private Transform playerCamera = null;
    [SerializeField]private float interactDist = 3f;

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


    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerCamera = Camera.main.transform;
        camPosition = playerCamera.localPosition;
        camRotation = playerCamera.localRotation;
        playerCamera.SetParent(gameObject.transform);
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.Find("RhythmController").GetComponent<RhythmGameManager>().gameActive)
        {
            // UpdateMouseLook();
            // UpdateMovement();
            UpdateNavMesh();
            ApplyGravity();
            CanInteract();
            CheckForMenuButtons();
        }
    }



    void UpdateNavMesh() {
            if (Input.GetMouseButtonDown(0)) {
                RaycastHit hit;
                
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
                    agent.destination = hit.point;
                }
            }
        }

    private void CheckForMenuButtons()
    {
        if (Input.GetButton("Pause"))
        {
            GameController.gameState = GameController.GameStates.Pause;
            GameController.gameStateChanged.Invoke();
        }
        else if (Input.GetButton("Inventory"))
        {
            GameController.gameState = GameController.GameStates.Inventory;
            GameController.gameStateChanged.Invoke();
        }
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

    public void CanInteract(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, interactDist)){
            if(hit.collider.CompareTag("Interactable")){
                // Debug.Log("Do you want to interact?");
                if(Input.GetButtonDown("Fire1")){
                    hit.collider.gameObject.SendMessage("OnInteract");
                }
                
            }
        }
    }
}
