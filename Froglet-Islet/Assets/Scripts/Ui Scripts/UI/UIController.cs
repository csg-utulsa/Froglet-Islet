using UnityEngine;

public class UIController : Singleton<UIController>
{
    public PauseScreen pauseScreen;
    public GameScreen gameScreen;
    public FinishScreen finishScreen;
    public JournalScreen journalScreen;
    public InventoryScreen InventoryScreen;

    void Awake()
    {
        //wait for actual game controller
        GameController.gameStateChanged.AddListener(OnGameStateChanged);
    }

    void OnGameStateChanged()
    {
        if (GameController.gameState == GameController.GameStates.Game)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        pauseScreen.SetState(GameController.gameState == GameController.GameStates.Pause);
        gameScreen.SetState(GameController.gameState == GameController.GameStates.Game || GameController.gameState == GameController.GameStates.Inventory);
        finishScreen.SetState(GameController.gameState == GameController.GameStates.Finish);
        journalScreen.SetState(GameController.gameState == GameController.GameStates.Dialog);
        InventoryScreen.SetState(GameController.gameState == GameController.GameStates.Inventory);
    }

    public void ShowError(string error)
    {
        //show the errors for debuging
        //SoundController.Play("error");
        gameScreen.ShowError(error);
    }
}