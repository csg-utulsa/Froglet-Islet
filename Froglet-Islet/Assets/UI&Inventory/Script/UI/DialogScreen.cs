using UnityEngine.UI;

public class JournalScreen : Form
{
    public Image iconImage;
    public Text nameText;
    public Text messageText;

    private Dialog dialog;
    private int index = 0;

    void Update()
    {
        if (IsShown == false) return;
        if (InputController.Use == true)
        {
            index++;
            if (index >= dialog.dialogItems.Count)
            {
                GameController.Instance.gameState = GameController.GameStates.Game;
            }
            else
            {
                Fill();
            }
        }
    }

    public void SetDialog(Dialog dialog)
    {
        if (dialog == null || dialog.dialogItems.Count == 0)
        {
            GameController.Instance.gameState = GameController.GameStates.Game;
            return;
        }
        this.dialog = dialog;
        index = 0;
        Fill();
    }

    private void Fill()
    {
        iconImage.sprite = dialog.dialogItems[index].icon;
        nameText.text = dialog.dialogItems[index].name;
        messageText.text = dialog.dialogItems[index].text;
    }
}