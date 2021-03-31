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

public class PlayerController : Singleton<PlayerController>
{
    Vector3 movement;
    NavMeshAgent agent;

    private Transform playerCamera = null;
    [SerializeField]private float interactDist = 20f;
    [SerializeField]private float clickMovementDist = 30f;

    CharacterController controller = null;
    private Vector2 currentDir = Vector2.zero;
    private Vector2 currentDirVelocity = Vector2.zero;

    private Vector2 currentMouseDelta = Vector2.zero;
    private Vector2 currentMouseDeltaVelocity = Vector2.zero;

    private Vector3 camPosition;

    private Quaternion camRotation;

    public GameObject markerPrefab;

    //
    public GameScreen GameScreen;

    // Song: set interactive object for Dialog
    public IInteractive InteractiveObject { get; private set; }

    //The checkmarker exists for when a new marker may need to be made, but that depends on
    private enum MarkerState{
        NoMarker,
        AddMarker,
        HasMarker
    }

    private MarkerState m_markerState;

    private GameObject markerInstance;
    private Vector3 markerPosition;

    private GameObject hoverObject;
    private bool hasSentHover = false;


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
        //Song: Keep checking the use function.
        if ((InteractiveObject != null) && (InputController.Use))
        {
            InteractiveObject.Use();
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
            
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, clickMovementDist)) {
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
            //Song: change game states
            GameController.gameState = GameStates.Pause;
            //GameController.gameStateChanged.Invoke();
        }
        else if (Input.GetButton("Inventory"))
        {
            // Song: change game states
            GameController.gameState = GameStates.Inventory;
            //GameController.gameStateChanged.Invoke();
        }
    }
    // Song: change the trigger for checking interact object
    private void OnTriggerEnter(Collider other)
    {
        
        InteractiveObject = other.gameObject.GetComponent(typeof(IInteractive)) as IInteractive;
        if (InteractiveObject != null && InteractiveObject.IsActive == false) InteractiveObject = null;
        if (InteractiveObject != null && InteractiveObject.Action == InteractiveAction.Show)
        {
            GameScreen.timeRemaining = 5;
        }
        //Song: active the item
        
    }

    public bool CanInteract(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, interactDist)){
            if(hit.collider.CompareTag("Interactable")){
                if(hoverObject == null){
                    hoverObject = hit.collider.gameObject;
                    hasSentHover = false;
                } else if(hoverObject != hit.collider.gameObject){
                    hoverObject.SendMessage("OnHoverExit", SendMessageOptions.DontRequireReceiver);
                    hoverObject = hit.collider.gameObject;     
                }
                if(!hasSentHover){
                    hoverObject.SendMessage("OnHoverEnter",SendMessageOptions.DontRequireReceiver);
                    hasSentHover = true;
                }
                // Debug.Log("Do you want to interact?");
                if(Input.GetButtonDown("Fire1")){
                    hoverObject.SendMessage("OnInteract");
                    return true;
                }
                
            } else if(hoverObject != null){
                hoverObject.SendMessage("OnHoverExit",SendMessageOptions.DontRequireReceiver);
                hoverObject = null;
            }
        } else if(hoverObject != null){
            hoverObject.SendMessage("OnHoverExit",SendMessageOptions.DontRequireReceiver);
            hoverObject = null;
        }
        
        return false;
    }
}
