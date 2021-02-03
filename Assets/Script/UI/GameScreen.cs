using UnityEngine;
using UnityEngine.UI;

public class GameScreen : Form
{
    public Image crosshair;
    public ItemSlot[] slots;
    
    public Text errorText;
    //public Image hitEffect;
    //public Color hitEffectColor;

    private float errorShowTime = -1;

    void Update()
    {
        if (IsShown == false) return;
        PlayerController player = PlayerController.Instance;

        //Interactive object
        /*
        useText.gameObject.SetActive(player.InteractiveObject != null);
        if (player.InteractiveObject != null)
        {
            if (player.InteractiveObject.Action == InteractiveAction.Use) useText.text = "PRESS E TO USE " + player.InteractiveObject.Name.ToUpper();
            if (player.InteractiveObject.Action == InteractiveAction.Take) useText.text = "PRESS E TO TAKE " + player.InteractiveObject.Name.ToUpper();
            if (player.InteractiveObject.Action == InteractiveAction.Read) useText.text = "PRESS E TO READ " + player.InteractiveObject.Name.ToUpper();
        }
        */

        // Hit effect
        /*
        if (Time.time - PlayerController.Instance.HitTime < 0.5f)
        {
            hitEffect.gameObject.SetActive(true);
            hitEffectColor.a = Mathf.Lerp(0.5f, 0f, (Time.time - PlayerController.Instance.HitTime)*2);
            hitEffect.color = hitEffectColor;
        }
        else
        {
            hitEffect.gameObject.SetActive(false);
        }
        */
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
