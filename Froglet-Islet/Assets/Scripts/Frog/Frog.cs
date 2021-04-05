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

    private RhythmGameManager rhythmGameManager;

    public GameScreen gamescreen;


    void Awake()
    {
        rhythmGameManager = GameObject.Find("RhythmController").GetComponent<RhythmGameManager>();
        gameObject.GetComponent<MeshRenderer>().material = frogData.frogMaterial;
    }
    
    public void OnInteract()
    {
        //If the frog has an item requirement that needs to be met, item must be found in player's inventory.
        if (InventoryController.Instance.FindAndRemoveItem(frogData.tollItem) || frogData.tollItem == "")
        {
            //Interact with frog
            gamescreen.ShowMessage(frogData.tollItem + " have been used.");

            rhythmGameManager.StartRhythmGame(this);
        }
        else
        {
            //Display that the player does not have the required item
            gamescreen.ShowMessage("This frog isn't interested...maybe I need some " + frogData.tollItem + "?" );
        }
    }
}
