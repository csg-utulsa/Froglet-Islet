using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippedItemScript : MonoBehaviour
{

    private string currentItem;
    LevelController lc;

    // Start is called before the first frame update
    void Start()
    {
        lc = GameObject.FindGameObjectWithTag("LevelController").GetComponent<LevelController>();
    }

    public void EquipItem(string ci) // should be called by inventory system
    {
        currentItem = ci;
    }

    public string GetEquippedItem()
    {
        return currentItem;
    }

    public void CheckConsumable(string f)
    {/*
        switch (f)
        {
            case "seeds":
                InventoryController.Instance.FindAndRemoveItem("Seeds");
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
                InventoryController.Instance.FindAndRemoveItem("Food");
                foreach (Frog fro in lc.GetFrogList())
                {
                    if (fro.frogData.frogSpecies == "storm")
                        fro.canInteract = true;
                }
                break;
            case "blossom":
                InventoryController.Instance.FindAndRemoveItem("Blossom");
                foreach (Frog fro in lc.GetFrogList())
                {
                    if (fro.frogData.frogSpecies == "flying")
                        fro.canInteract = true;
                }
                break;
            case "potion":
                InventoryController.Instance.FindAndRemoveItem("Potion");
                break;
            default:
                print("non-consumable used");
                break;
        }*/
    }

    /*
    public void ActivateItem() // should be called by UI button
    {
        switch (currentItem)
        {
            case "Seeds":
                ActivateSeeds();
                break;
            case "Tomato":
                ActivateTomato();
                break;
            case "Blossom":
                ActivateBlossom();
                break;
            case "Rainstick":
                ActivateRainstick();
                break;
            case "FishingRod":
                ActivateFishingRod();
                break;
            case "Bottle":
                ActivateBottle();
                break;
            case "FluteUpgrade":
                ActivateFluteUpgrade();
                break;
            case "Lantern":
                ActivateLantern();
                break;
            case "Potion":
                ActivatePotion();
                break;
            case "Key":
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

        foreach (Frog f in lc.GetFrogList())
        {
            if (f.frogData.frogSpecies == "slime")
                f.canInteract = true;
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
        GameObject.Find("Lantern").GetComponent<LanternScript>().Activate();
        */
    /*foreach (Frog f in lc.GetFrogList())
    {
        if (f.frogData.frogSpecies == "crystal")
            f.canInteract = true;
    }
    foreach (Frog f in lc.GetFrogList())
    {
        if (f.frogData.frogSpecies == "ancient")
            f.canInteract = true;
    }*/
    /*}

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

        */
}
