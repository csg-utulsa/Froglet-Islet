using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogS : MonoBehaviour, IInteractive
{
    public string objectName;
    public string dialogId;
    //public GameScreen gameScreen;

    public string Name { get { return objectName; } }
    public bool IsActive { get { return true; } }
    public InteractiveAction Action { get { return InteractiveAction.Show; } }


 
    
    /*
    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            gameScreen.SetDS(objectName);

        }
    }
    */
    public void Use()
    {
        
    }
    
}
