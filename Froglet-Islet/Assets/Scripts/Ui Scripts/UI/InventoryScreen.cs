using UnityEngine;
using UnityEngine.UI;

public class InventoryScreen : Form
{
    public ItemSlot[] slots;
    public EquippedItemScript equippedItemScript;
    public GameScreen gameScreen;

    public Text hintText;
    public Image largeItemIcon;
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

        foreach (Item item in InventoryController.Instance.items)
        {
            if (item != null && item.id != null)
            {
                bool isAlreadyInInventory = false;
                foreach (ItemSlot itemSlot in slots)
                {
                    if (itemSlot.ItemInSlot != null && itemSlot.ItemInSlot.name == item.name)
                    {
                        itemSlot.SetItem(item);
                        if (InventoryController.Instance.itemStacks[item.id] > 1)
                        {
                            itemSlot.numText.gameObject.SetActive(true);
                            itemSlot.numText.text = InventoryController.Instance.itemStacks[item.id].ToString();
                        }
                        else
                        {
                            itemSlot.numText.gameObject.SetActive(false);
                        }
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
                            if (InventoryController.Instance.itemStacks[item.id] > 1)
                            {
                                itemSlot.numText.gameObject.SetActive(true);
                                itemSlot.numText.text = InventoryController.Instance.itemStacks[item.id].ToString();
                            }
                            else
                            {
                                itemSlot.numText.gameObject.SetActive(false);
                            }
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
                itemSlot.numText.gameObject.SetActive(false);
            }
        }
    }

    public override void Show()
    {
        base.Show();
        hintText.text = "";
        largeItemIcon.sprite = null;
        largeItemIcon.color = new Color(255, 255, 255, 0);
    }

    private void OnSlotClick(ItemSlot slot)
    {
        if (slot.ItemInSlot != null && slot.ItemInSlot.name == "Lantern")
        {
            if (equippedItemScript.name != null)
            {
                if (equippedItemScript.GetEquippedItem() == slot.ItemInSlot.name)
                {
                    equippedItemScript.EquipItem(null);
                    gameScreen.ShowMessage("Stopped holding " + slot.ItemInSlot.name);
                }
                else
                {
                    equippedItemScript.EquipItem(slot.ItemInSlot.name);
                    gameScreen.ShowMessage("Equipped " + slot.ItemInSlot.name);
                }
            }
        }
    }

    private void OnSlotHover(ItemSlot slot, bool state)
    {
        if (state == true)
        {
            hoveredSlot = slot;
            if (slot.ItemInSlot != null)
            {
                hintText.text = slot.ItemInSlot.name + "\n" + slot.ItemInSlot.description;
                largeItemIcon.sprite = slot.ItemInSlot.icon;
                largeItemIcon.color = new Color(255, 255, 255, 255);
            }
        }
        else
        {
            hoveredSlot = null;
            hintText.text = "";
            largeItemIcon.sprite = null;
            largeItemIcon.color = new Color(255,255,255,0);
        }
    }
}
