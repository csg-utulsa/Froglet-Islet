using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour, IInteractable
{
    //Assigned to Logan Edmund
    //Last updated 2/8/21

    //Standard name for the Frog - what the player will see during normal gameplay
    public string frogName;
    //Species handles the specific offshoot of frog
    public string frogSpecies;
    //Genus handles the overall frog type -- handles what model and behaviors the frog will have
    public string frogGenus;
    //FrogID is a numeric value that can give all frogs a quick reference from the game controller
    public int frogID;
    //frogMaterial is a material assigned that will give the frog it's unique texture
    public Material frogMaterial;

    //frogModel keeps track of which model (and possibly animation sets) will be used for the frog
    public GameObject frogModel;

    //Keeps track of wether or not the frog species has been collected by the player
    public int frogCollected;

    public Rhythm frogMelody;
    public AudioClip frogCry;

    public bool canInteract = true;

    private RhythmGameManager rhythmGameManager;

    void Start()
    {
        rhythmGameManager = GameObject.Find("RhythmController").GetComponent<RhythmGameManager>();
    }
    
    public void OnInteract(){
        if(canInteract){
            rhythmGameManager.StartRhythmGame(this);
        }
    }


}
