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
            itemSlot.onHover += OnSlotHover;
        }
        foreach (ItemSlot itemSlot in UIController.Instance.gameScreen.slots)
        {
            itemSlot.onHover += OnSlotHover;
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
