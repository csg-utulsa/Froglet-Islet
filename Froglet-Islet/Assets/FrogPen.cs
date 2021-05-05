using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogPen : MonoBehaviour
{
    public List<GameObject> frogPrefabs = new List<GameObject>();
    Dictionary<string, int> frogs = new Dictionary<string, int>();

    private void Awake()
    {
        for (int i = 0; i < frogPrefabs.Count; i++)
        {
            Frog frog = frogPrefabs[i].GetComponent<Frog>();
            if (frog != null)
            {
                frogs.Add(frog.frogData.frogName, i);
            }
        }
    }

    public bool SpawnFrog(string frog)
    {
        int index = -1;
        bool canSpawnFrog = frogs.TryGetValue(frog, out index);
        if (canSpawnFrog)
        {
            Instantiate(frogPrefabs[index]);
        }
        return canSpawnFrog;
    }
}
