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
    InventoryController icS;
    GameScreen gameScreenS;
    Animator animator;

    ParticleEffectScript particleEffectS;

    void Awake()
    {
        particleEffectS = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<ParticleEffectScript>();
        animator = GetComponentInChildren<Animator>();
        gameScreenS = GameObject.Find("UI").GetComponentInChildren<GameScreen>();
        icS = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<InventoryController>();
        rhythmGameManager = GameObject.Find("RhythmController").GetComponent<RhythmGameManager>();
        gameObject.GetComponent<MeshRenderer>().material = frogData.frogMaterial;
    }

    void Start()
    {
        
    }

    public void OnInteract()
    {
        if (icS.FindItem("FluteBase") != null)
        {
            //If the frog has an item requirement that needs to be met, item must be found in player's inventory.
            if (InventoryController.Instance.FindAndRemoveItem(frogData.tollItem.name) || frogData.tollItem.name == "")
            {
                if(frogData.tollItem.name != "")
                    particleEffectS.RainbowRiseEffect();
                //Interact with frog
                rhythmGameManager.StartRhythmGame(this);
            }
        }
        else
        {
            gameScreenS.ShowMessage("Missing flute!");
        }
    }

    public void JumpAnimation()
    {
        animator.SetBool("jumping", true);
        StartCoroutine("DelayEndJumpingState");
    }

    IEnumerator DelayEndJumpingState()
    {
        yield return new WaitForSeconds(0.01f);
        animator.SetBool("jumping", false);
    }
}
