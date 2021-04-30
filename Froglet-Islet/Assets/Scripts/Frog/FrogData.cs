//Assigned to Logan Edmund
//Last updated by Logan Edmund on 3/3/21
//  -Fully Implemented FrogData class



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FrogData
{
    //Standard name for the Frog - what the player will see during normal gameplay
    public string frogName;
    //Description for the Frog - what the player will see in their journal
    public string frogDescription;
    //Species handles the specific offshoot of frog
    public string frogSpecies;
    //Genus handles the overall frog type -- handles what model and behaviors the frog will have
    public string frogGenus;
    //FrogID is a numeric value that can give all frogs a quick reference from the game controller
    public int frogID;
    //tollItem is the name of an Item that is needed in order to interact with the frog.
    public string tollItem;
    //consumeIten determines whether the toll item is consumed when interacting.
    public bool consumeTollItem;
    //frogSprite is the 2D sprite associated with the frog when displayed in a 2D environment such as the journal
    public Sprite frogSprite;
    //frogMaterial is a material assigned that will give the frog it's unique texture
    public Material frogMaterial;
    //frogModel keeps track of which model (and possibly animation sets) will be used for the frog
    public GameObject frogModel;
    //Keeps track of whether or not the frog species has been collected by the player
    public bool frogCollected;
    //The melody accessed by the rhythm game that determines what the rhythm game is
    public Rhythm frogMelody;
    //Sound that the frog makes at some point lol I dunno
    public AudioClip frogCry;
    //Location to spawn in by FrogSpawnerScript
    public Vector3 spawnLocation;
    //Stores information about what items the frog can potentially give the player after completion of the Rhythm Githem
    public Item itemDrop;

}
