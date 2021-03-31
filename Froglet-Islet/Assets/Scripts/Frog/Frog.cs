//Assigned to Logan Edmund
//Last updated by Logan Edmund on 3/3/21
//  -Changed Start() to Awake() and added ability to assign material to model at appropriate time
//  -Moved all variables that are frog-specific into the FrogData class

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour, IInteractable
{
    

    public FrogData frogData;

    

    public bool canInteract = true;

    private RhythmGameManager rhythmGameManager;


    void Awake()
    {
        rhythmGameManager = GameObject.Find("RhythmController").GetComponent<RhythmGameManager>();
        gameObject.GetComponent<MeshRenderer>().material = frogData.frogMaterial;
    }
    
    public void OnInteract(){
        if(canInteract)
        {
            //If the frog has an item requirement that needs to be met, item must be found in player's inventory.
            //if (CheckInventoryForItem())
                //Interact with frog
            rhythmGameManager.StartRhythmGame(this);
        }
    }

    //Checks the player's inventory for items needed to interact with the frog.
    private bool CheckInventoryForItem()
    {
        //Get reference to the player's inventory
        //for each item in the player's inventory:
        {
            //if an item is found that matches the tollItem, the frog can be interacted with
                //return true;
        }
        //If the end of the loop has been reached and the item does not exist, then we cannot interact with the frog.
            //return false;


        //This return true line only exists so the code doesn't have a fit
        return true;
    }

}
