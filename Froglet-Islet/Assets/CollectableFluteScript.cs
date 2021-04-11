using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CollectableFluteScript : MonoBehaviour, IInteractable
{

    public NavMeshObstacle barrier;
    //GameScreen gameScreenS;
    MeshRenderer[] allMR;
    Collider collider;
    InventoryController icS;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider>();
        allMR = GetComponentsInChildren<MeshRenderer>();
        //gameScreenS = GameObject.Find("UI").GetComponentInChildren<GameScreen>();
        icS = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<InventoryController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnInteract()
    {
        barrier.enabled = false;
        //gameScreenS.ShowMessage("Collected flute!");
        icS.AddItem(new Flute());
        foreach (MeshRenderer mr in allMR)
            mr.enabled = false;
        collider.enabled = false;
    }
}
