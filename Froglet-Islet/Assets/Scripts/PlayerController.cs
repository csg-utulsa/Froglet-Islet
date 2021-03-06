﻿/* 
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


    CharacterController controller = null;
    private Vector2 currentDir = Vector2.zero;
    private Vector2 currentDirVelocity = Vector2.zero;

    private Vector2 currentMouseDelta = Vector2.zero;
    private Vector2 currentMouseDeltaVelocity = Vector2.zero;

    private Vector3 camPosition;

    private Quaternion camRotation;

    public GameObject markerPrefab;
    //The checkmarker exists for when a new marker may need to be made, but that depends on
    private enum MarkerState{
        NoMarker,
        AddMarker,
        HasMarker
    }

    private MarkerState m_markerState;

    private GameObject markerInstance;
    private Vector3 markerPosition;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerCamera = Camera.main.transform;
        playerCamera.SetParent(gameObject.transform);
        agent = GetComponent<NavMeshAgent>();
        m_markerState = MarkerState.NoMarker;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.Find("RhythmController").GetComponent<RhythmGameManager>().gameActive)
        {
            if(!CanInteract())
                UpdateNavMesh();
            CheckForMenuButtons();
            CreateMarker();
        }
    }

    void CreateMarker(){
        if(m_markerState == MarkerState.HasMarker){
            return;
        } else if(m_markerState == MarkerState.AddMarker){
            if(markerPosition != agent.destination){
                markerPosition = agent.destination;
                markerInstance = Instantiate(markerPrefab,markerPosition,Quaternion.Euler(new Vector3(-90,0,0)));
                m_markerState = MarkerState.HasMarker;
            }
            
        } else if(markerInstance == null){
            m_markerState = MarkerState.NoMarker;
        }
        
    }

    //I am putting this in player for now, but we may want to move it.


    void UpdateNavMesh() {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
                agent.destination = hit.point;
                if(markerInstance != null){
                    markerInstance.GetComponent<Marker>().RemoveMarker();
                    markerInstance = null;
                }
                m_markerState = MarkerState.AddMarker;
                
            }
        }
    }



    private bool ArrivedAtPosition(){
        if(!agent.pathPending){
            if(agent.remainingDistance <= agent.stoppingDistance){
                if(!agent.hasPath || agent.velocity.sqrMagnitude == 0f) return true;
            }
        }
        return false;
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

    public bool CanInteract(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, interactDist)){
            if(hit.collider.CompareTag("Interactable")){
                // Debug.Log("Do you want to interact?");
                if(Input.GetButtonDown("Fire1")){
                    hit.collider.gameObject.SendMessage("OnInteract");
                    return true;
                }
                
            }
        }
        return false;
    }
}
