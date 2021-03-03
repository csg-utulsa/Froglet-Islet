using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour, IInteractable
{
    //Assigned to Logan Edmund
    //Last updated 2/8/21

    public FrogData frogData;
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
