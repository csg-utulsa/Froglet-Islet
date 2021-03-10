using UnityEngine;
using UnityEngine.UI;

public class GameScreen : Form
{
    public Image crosshair;
    public ItemSlot[] slots;
    public Text useText;
    public Text errorText;
    

    private float errorShowTime = -1;

    void Update()
    {
        if (IsShown == false) return;
        PlayerController player = PlayerController.Instance;

        //interactive object
        
        useText.gameObject.SetActive(player.InteractiveObject != null);
        if (player.InteractiveObject != null)
        {
            if (player.InteractiveObject.Action == InteractiveAction.Read) useText.text = "PRESS E TO READ " + player.InteractiveObject.Name.ToUpper();
        }
        

        if (Time.time - errorShowTime > 0.5f) errorText.gameObject.SetActive(false);

        // Slots
        foreach (ItemSlot slot in slots)
        {
            slot.SetItem(InventoryController.Instance.Items[slot.id]);
        }
    }

    public void ShowError(string text)
    {
        errorText.gameObject.SetActive(true);
        errorText.text = text;
        errorShowTime = Time.time;
    }
}
