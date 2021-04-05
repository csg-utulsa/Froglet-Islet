using UnityEngine;
using UnityEngine.UI;

public class GameScreen : Form
{

    //public ItemSlot[] slots;
    public Text useText;
    public Text errorText;
    public Text showMessage;
    public string Message;
    public bool DS = false;
    public float timeRemaining { get; set; }

    private float errorShowTime = -1;

    void Start()
    {
        showMessage.gameObject.SetActive(false);
        timeRemaining = 0;
    }
    void Update()
    {
        if (IsShown == false) return;
        PlayerController player = PlayerController.Instance;

        //interactive object

        /*
        if (DS == true)
        {
            showMessage.gameObject.SetActive(true);
            showMessage.text = player.InteractiveObject.Name.ToUpper();
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                showMessage.gameObject.SetActive(false);
                DS = false;
            }

        }
        */
        if (player.InteractiveObject != null)
        {
            if (player.InteractiveObject.Action == InteractiveAction.Read)
            {

                useText.gameObject.SetActive(true);
                useText.text = "PRESS E TO READ " + player.InteractiveObject.Name.ToUpper();
            }

            if (player.InteractiveObject.Action == InteractiveAction.Show)
            {

                showMessage.gameObject.SetActive(true);
                showMessage.text = player.InteractiveObject.Name.ToUpper();
            }

        }
        else
        {
            useText.gameObject.SetActive(false);
            
        }
        

        if (timeRemaining > 0)
        {
            
            timeRemaining -= Time.deltaTime;
        }
        else
        {

            showMessage.gameObject.SetActive(false);
        }


        if (Time.time - errorShowTime > 0.5f) errorText.gameObject.SetActive(false);

        // Slots
        /*
        foreach (ItemSlot slot in slots)
        {
            slot.SetItem(InventoryController.Instance.Items[slot.id]);
        }
        */
    }

    public void ShowMessage(string input)
    {
        timeRemaining = 5;
        showMessage.text = input;
        showMessage.gameObject.SetActive(true);
    }

    public void ShowError(string text)
    {
        errorText.gameObject.SetActive(true);
        errorText.text = text;
        errorShowTime = Time.time;
    }
}
