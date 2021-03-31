using UnityEngine;
using UnityEngine.UI;

public class InventoryScreen : Form
{
    public ItemSlot[] slots;
    public EquippedItemScript equippedItemScript;
    public GameScreen gameScreen;

    public Text hintText;
    public Image dragIcon;
    public Color defaultTextColor = Color.grey;
    public Color highlightTextColor = Color.green;

    private ItemSlot hoveredSlot;

    void Start()
    {
        hintText.text = "";

        foreach (ItemSlot itemSlot in slots)
        {
            itemSlot.onHover += OnSlotHover;
            itemSlot.onClick += OnSlotClick;
        }
    }

    void Update()
    {
        if (IsShown == false) return;

        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rootPanel.GetComponent<RectTransform>(), Input.mousePosition, null, out localPoint);
        if (dragIcon.gameObject.activeSelf == true)
        {
            dragIcon.transform.parent.GetComponent<RectTransform>().anchoredPosition = localPoint;
        }

        foreach (Item item in InventoryController.Instance.items)
        {
            if (item != null)
            {
                bool isAlreadyInInventory = false;
                foreach (ItemSlot itemSlot in slots)
                {
                    if (itemSlot.ItemInSlot != null && itemSlot.ItemInSlot.name == item.name)
                    {
                        itemSlot.SetItem(item);
                        isAlreadyInInventory = true;
                        break;
                    }
                }

                if (!isAlreadyInInventory)
                {
                    foreach (ItemSlot itemSlot in slots)
                    {
                        if (itemSlot.slotType == item.itemType && itemSlot.ItemInSlot == null)
                        {
                            itemSlot.SetItem(item);
                            break;
                        }
                    }
                }
            }
        }
        foreach (ItemSlot itemSlot in slots)
        {
            if (!InventoryController.Instance.items.Contains(itemSlot.ItemInSlot))
            {
                itemSlot.SetItem(null);
            }
        }
    }

    public override void Show()
    {
        base.Show();
        hintText.text = "";
        dragIcon.gameObject.SetActive(false);
    }

    private void OnSlotClick(ItemSlot slot)
    {
        if (slot.ItemInSlot != null)
        {
            equippedItemScript.EquipItem(slot.ItemInSlot.name);
            gameScreen.ShowMessage("Equipped " + slot.ItemInSlot.name);
        }
    }

    private void OnSlotHover(ItemSlot slot, bool state)
    {
        if (state == true)
        {
            hoveredSlot = slot;
            if (slot.ItemInSlot != null) hintText.text = slot.ItemInSlot.name + slot.ItemInSlot.description;
        }
        else
        {
            hoveredSlot = null;
            hintText.text = "";
        }
    }
}
