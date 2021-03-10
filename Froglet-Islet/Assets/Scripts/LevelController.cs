using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    List<Frog> frogList = new List<Frog>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CullFrogList()
    {
        List<Frog> removeFrogs = PlayerPrefs.CaughtFrogs;
        foreach (Frog f in removeFrogs)
        {
            f.gameObject.SetActive(false);
            frogList.Remove(f);
        }
    }

    public List<Frog> GetFrogList()
    {
        return frogList;
    }

    public void SetFrogList(List<Frog> pList)
    {
        frogList = pList;
    }

}

