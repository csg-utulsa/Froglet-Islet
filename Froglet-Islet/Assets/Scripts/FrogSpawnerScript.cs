using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogSpawnerScript : MonoBehaviour
{
    public GameObject[] allFrogPrefabs;
    Frog[] frogScripts;

    private void Awake()
    {
        frogScripts = new Frog[allFrogPrefabs.Length];
        for (int i = 0; i < allFrogPrefabs.Length; i++)
        {
            frogScripts[i] = allFrogPrefabs[i].GetComponent<Frog>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Spawn(int id)
    {
        for (int i = 0; i < frogScripts.Length; i++)
        {
            if (frogScripts[i].frogData.frogID == id)
            {
                Instantiate(allFrogPrefabs[i], frogScripts[i].frogData.spawnLocation, Quaternion.identity);
                break;
            }
        }
    }

}
