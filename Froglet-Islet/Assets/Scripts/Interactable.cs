/* 
    Author: Jacob Regan
    Data Created: 1/30/21
    Last Modified Data: 2/3/21
    Last Modified By: Jacob Regan
    Description:  The base Interactable class for interactive objects.
        Override the OnInteract() function for different types

 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//May not need
public enum InteractableType {
    Default,
    Frog,
    Tool
}

public class Interactable : MonoBehaviour
{
    /* Public Variables*/
    public string Name;

    public string InteractText = "Click to interact.";

    public InteractableType Type;

    public bool canInteract = true;

    public float interactDist = 3f;

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        CanInteract();
    }


    public void CanInteract(){
        if(!canInteract) return;

        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, interactDist)){
            if(hit.collider.CompareTag("Interactable")){
                Debug.Log("Do you want to interact?");
                if(Input.GetButtonDown("Fire1")){
                    OnInteract();
                }
                
            }
        }
    }

    //Use this for functionality, should probably handle with event system.
    public virtual void OnInteract(){
        Debug.Log("Interacted with ");
        canInteract = false;
    }
    
    


}
