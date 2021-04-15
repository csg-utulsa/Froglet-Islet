using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CollectableFluteScript : MonoBehaviour, IInteractable
{
    public Sprite fluteSprite;
    public NavMeshObstacle barrier;
    GameScreen gameScreenS;
    MeshRenderer[] allMR;
    Collider collider;
    InventoryController icS;
    

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider>();
        allMR = GetComponentsInChildren<MeshRenderer>();
        gameScreenS = GameObject.Find("UI").GetComponentInChildren<GameScreen>();
        icS = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<InventoryController>();
        StartCoroutine("DelayPickupFluteHint");
    }

    IEnumerator DelayPickupFluteHint()
    {
        yield return new WaitForSeconds(0.01f);
        gameScreenS.ShowMessage("Pick up the flute. You'll need it to collect frogs!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnInteract()
    {
        barrier.enabled = false;
        icS.AddItem(new Flute(fluteSprite));
        foreach (MeshRenderer mr in allMR)
            mr.enabled = false;
        collider.enabled = false;
    }
}
