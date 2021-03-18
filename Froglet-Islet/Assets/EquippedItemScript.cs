using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippedItemScript : MonoBehaviour
{

    private int currentItem;
    LevelController lc;
    ItemsController ic;

    // Start is called before the first frame update
    void Start()
    {
        lc = GameObject.FindGameObjectWithTag("LevelController").GetComponent<LevelController>();
        ic = GameObject.FindGameObjectWithTag("ItemsController").GetComponent<ItemsController>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
                ActivateSeeds();
                break;
            case 1:
                ActivateTomato();
                break;
            case 2:
                ActivateBlossom();
                break;
            case 3:
                ActivateRainstick();
                break;
            case 4:
                ActivateFishingRod();
                break;
            case 5:
                ActivateBottle();
                break;
            case 6:
                ActivateFluteUpgrade();
                break;
            case 7:
                ActivateLantern();
                break;
            case 8:
                ActivatePotion();
                break;
            case 9:
                ActivateKey();
                break;
            default:
                print("WARNING! INVALID ITEM");
                break;
        }
    }


    private void ActivateSeeds()
    {
        foreach (Frog f in lc.GetFrogList())
        {
            if (f.frogData.frogSpecies == "tomato")
                f.canInteract = true;
            if (f.frogData.frogSpecies == "flower")
                f.canInteract = true;
        }
    }

    private void ActivateTomato()
    {
        foreach (Frog f in lc.GetFrogList())
        {
            if (f.frogData.frogSpecies == "storm")
                f.canInteract = true;
        }
    }

    private void ActivateBlossom()
    {
        foreach (Frog f in lc.GetFrogList())
        {
            if (f.frogData.frogSpecies == "flying")
                f.canInteract = true;
        }
    }

    private void ActivateRainstick()
    {
        foreach (Frog f in lc.GetFrogList())
        {
            if (f.frogData.frogSpecies == "giant")
                f.canInteract = true;
        }
    }

    private void ActivateFishingRod()
    {
        foreach (Frog f in lc.GetFrogList())
        {
            if (f.frogData.frogSpecies == "bubble")
                f.canInteract = true;
        }
        foreach (Frog f in lc.GetFrogList())
        {
            if (f.frogData.frogSpecies == "siren")
                f.canInteract = true;
        }
    }

    private void ActivateBottle()
    {
        bool found = false;
        foreach (Frog f in PlayerPrefs.CaughtFrogs)
            if (f.frogData.frogSpecies == "Firefly")
                found = true;
        if (found)
        {
            foreach (Frog f in lc.GetFrogList())
            {
                if (f.frogData.frogSpecies == "slime")
                    f.canInteract = true;
            }
        }
    }

    private void ActivateFluteUpgrade()
    {
        foreach (Frog f in lc.GetFrogList())
        {
            if (f.frogData.frogSpecies == "firefly")
                f.canInteract = true;
        }
        InventoryController.Instance.RemoveItem("Flute");
        InventoryController.Instance.AddItem(new FluteLevel2());
    }

    private void ActivateLantern()
    {
        bool found = false;
        foreach (Frog f in PlayerPrefs.CaughtFrogs)
            if (f.frogData.frogSpecies == "BubbleFrog")
                found = true;
        if (found)
        {
            foreach (Frog f in lc.GetFrogList())
            {
                if (f.frogData.frogSpecies == "slime")
                    f.canInteract = true;
            }
        }

        foreach (Frog f in lc.GetFrogList())
        {
            if (f.frogData.frogSpecies == "crystal")
                f.canInteract = true;
        }
        foreach (Frog f in lc.GetFrogList())
        {
            if (f.frogData.frogSpecies == "ancient")
                f.canInteract = true;
        }
    }

    private void ActivatePotion()
    {
        PlayerPrefs.AvailableActions.Add("breed");
    }

    private void ActivateKey()
    {
        foreach (Frog f in lc.GetFrogList())
        {
            if (f.frogData.frogSpecies == "treasure")
                f.canInteract = true;
        }
        foreach (Frog f in lc.GetFrogList())
        {
            if (f.frogData.frogSpecies == "ceramic")
                f.canInteract = true;
        }
    }

    public void CheckIfConsumable(string f)
    {
        switch (f)
        {
            case "seeds":
                InventoryController.Instance.RemoveItem("Seeds");
                foreach (Frog fro in lc.GetFrogList())
                {
                    if (fro.frogData.frogSpecies == "flower")
                        fro.canInteract = true;
                }
                foreach (Frog fro in lc.GetFrogList())
                {
                    if (fro.frogData.frogSpecies == "tomato")
                        fro.canInteract = true;
                }
                break;
            case "food":
                InventoryController.Instance.RemoveItem("Food");
                foreach (Frog fro in lc.GetFrogList())
                {
                    if (fro.frogData.frogSpecies == "storm")
                        fro.canInteract = true;
                }
                break;
            case "blossom":
                InventoryController.Instance.RemoveItem("Blossom");
                foreach (Frog fro in lc.GetFrogList())
                {
                    if (fro.frogData.frogSpecies == "flying")
                        fro.canInteract = true;
                }
                break;
            case "potion":
                InventoryController.Instance.RemoveItem("Potion");
                break;
            default:
                print("non-consumable used");
                break;
        }
    }
}
