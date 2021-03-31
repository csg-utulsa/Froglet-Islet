using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippedItemScript : MonoBehaviour
{

    private int currentItem;
    LevelController lc;

    // Start is called before the first frame update
    void Start()
    {
        lc = GameObject.FindGameObjectWithTag("LevelController").GetComponent<LevelController>();
    }

    public void EquipItem(int ci) // should be called by inventory system
    {
        currentItem = ci;
    }

    public void ActivateItem() // should be called by UI button
    {
        switch (currentItem)
        {
            case 0:
                ActivateTomato();
                break;
            default:
                print("WARNING! INVALID ITEM");
                break;
        }
    }

    private void ActivateTomato()
    {
        foreach (Frog f in lc.GetFrogList())
        {
            if (f.frogID == 0)
                f.gameObject.SetActive(true);
        }
    }


}
