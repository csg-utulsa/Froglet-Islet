using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogPen : MonoBehaviour
{
    List<GameObject> frogsSpawned = new List<GameObject>();

    public void SpawnFrog(Frog frog)
    {
        if (frog.frogData.frogModel != null)
        {
            frogsSpawned.Add(Instantiate(frog.frogData.frogModel));
        }    
    }
}
