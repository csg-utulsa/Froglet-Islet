using UnityEngine;
using UnityEngine.UI;

public class GameScreen : Form
{
    public Image crosshair;
    public ItemSlot[] slots;
    
    public Text errorText;

    private float errorShowTime = -1;

    void Update()
    {
        if (IsShown == false) return;
        if (Time.time - errorShowTime > 0.5f) errorText.gameObject.SetActive(false);

        // Slots
        foreach (ItemSlot slot in slots)
        {
            slot.SetItem(InventoryController.Instance.items[slot.id]);
        }
    }

    public void ShowError(string text)
    {
        errorText.gameObject.SetActive(true);
        errorText.text = text;
        errorShowTime = Time.time;
    }
}
