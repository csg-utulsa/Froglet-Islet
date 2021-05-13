using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boat : MonoBehaviour, IInteractable
{
    public void OnInteract()
    {
        if (InventoryController.Instance.CheckForItem("Treasure"))
        {
            SceneManager.LoadScene("EndingScene");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
