using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public enum SlotTypes
    {
        Backpack = 0,
    }

    public Image icon;
    public int id = 0;
    public bool showHotkeyLabel = false;
    public SlotTypes slotType = SlotTypes.Backpack;

    public Item ItemInSlot { get; private set; }


    public void SetItem(Item item)
    {
        ItemInSlot = item;
        if (item == null || item.id == "")
        {
            icon.gameObject.SetActive(false);
        }
        else
        {
            icon.gameObject.SetActive(true);
            icon.sprite = item.icon;
        }
    }

}
