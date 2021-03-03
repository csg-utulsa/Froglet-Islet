using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Frog", menuName = "Frog")]
public class Frog : ScriptableObject
{
    //Assigned to Logan Edmund
    //Last updated 2/8/21

    public FrogData frogData;
    //Keeps track of wether or not the frog species has been collected by the player
    public int frogCollected;

    //public Rhythm frogMelody;
    public AudioClip frogCry;

    void Start()
    {
        //

    }


}
