using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CaveBarrierScript : MonoBehaviour
{
    NavMeshObstacle nma;

    private void Awake()
    {
        nma = GetComponent<NavMeshObstacle>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableBarrier()
    {
        nma.enabled = false;
    }

    public void EnableBarrier()
    {
        nma.enabled = true;
    }
}
