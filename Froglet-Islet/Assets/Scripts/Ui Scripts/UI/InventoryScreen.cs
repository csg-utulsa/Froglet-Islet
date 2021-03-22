using UnityEngine;
using UnityEngine.UI;

public class InventoryScreen : Form
{
    public ItemSlot[] slots;

    public Text hintText;
    public Color defaultTextColor = Color.grey;
    public Color highlightTextColor = Color.green;

    void Start()
    {
        
        hintText.text = "";
    }

    void Update()
    {
        if (IsShown == false) return;

        PlayerController player = PlayerController.Instance;


        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rootPanel.GetComponent<RectTransform>(), Input.mousePosition, null, out localPoint);

        
        foreach (ItemSlot slot in slots)
        {
            slot.SetItem(InventoryController.Instance.Items[slot.id]);
        }
    }

    public override void Show()
    {
        base.Show();
        hintText.text = "";
    }

   /*
    * If we need a button on inventory screen 
    private void OnClick()
    {

    }
    */


    
    
}
