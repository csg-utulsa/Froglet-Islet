using UnityEngine;
using UnityEngine.UI;

public class InventoryScreen : Form
{
    public ItemSlot[] slots;
    public ItemSlot dropSlot;

    public Text hintText;
    public Image dragIcon;
    public Color defaultTextColor = Color.grey;
    public Color highlightTextColor = Color.green;

    private ItemSlot hoveredSlot;

    void Start()
    {
        
        hintText.text = "";

        dropSlot.onHover += OnSlotHover;

        foreach (ItemSlot itemSlot in slots)
        {
            itemSlot.onDblClick += OnSlotDblClick;
            itemSlot.onHover += OnSlotHover;
            itemSlot.onDrag += OnSlotDrag;
        }
        foreach (ItemSlot itemSlot in UIController.Instance.gameScreen.slots)
        {
            itemSlot.onDblClick += OnSlotDblClick;
            itemSlot.onHover += OnSlotHover;
            itemSlot.onDrag += OnSlotDrag;
        }
    }

    void Update()
    {
        if (IsShown == false) return;

        //wait for player information
        //PlayerController player = PlayerController.Instance;


        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rootPanel.GetComponent<RectTransform>(), Input.mousePosition, null, out localPoint);
        if (dragIcon.gameObject.activeSelf == true)
        {
            dragIcon.transform.parent.GetComponent<RectTransform>().anchoredPosition = localPoint;
        }

        
        foreach (ItemSlot slot in slots)
        {
            slot.SetItem(InventoryController.Instance.Items[slot.id]);
        }
    }

    public override void Show()
    {
        base.Show();
        hintText.text = "";
        dragIcon.gameObject.SetActive(false);
    }

   /*
    * If we need a button on inventory screen 
    private void OnClick()
    {

    }
    */

    private void OnSlotDblClick(ItemSlot slot)
    {
        //if we need to use the consumables
        //InventoryController.Instance.UseItem(slot.id);
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

    private void OnSlotDrag(ItemSlot slot, bool state)
    {
        if (state == true)
        {
            if (slot.ItemInSlot != null)
            {
                dragIcon.gameObject.SetActive(true);
                dragIcon.sprite = slot.ItemInSlot.icon;
            }
        }
        else
        {
            if (slot.ItemInSlot != null && hoveredSlot != null)
            {
                if (hoveredSlot.slotType == ItemSlot.SlotTypes.Backpack)
                {
                    InventoryController.Instance.Move(slot.id, hoveredSlot.id);
                }
            }
            dragIcon.gameObject.SetActive(false);
        }
    }
}
