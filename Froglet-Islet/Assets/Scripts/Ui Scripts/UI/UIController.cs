using UnityEngine;

public class UIController : Singleton<UIController>
{
    public PauseScreen pauseScreen;
    public GameScreen gameScreen;
    public FinishScreen finishScreen;
    public DialogScreen dialogScreen;
    public InventoryScreen InventoryScreen;

    void Awake()
    {
        //GameController.gameStateChanged.AddListener(OnGameStateChanged);
        
        GameController.Instance.onStateChanged += OnGameStateChanged;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameController.Instance.GameState == GameStates.Game)
            {
                GameController.Instance.GameState = GameStates.Pause;
            }
            else if (GameController.Instance.GameState == GameStates.Pause)
            {
                GameController.Instance.GameState = GameStates.Game;
            }
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            if (GameController.Instance.GameState == GameStates.Game)
            {
                GameController.Instance.GameState = GameStates.Inventory;
            }
            else if (GameController.Instance.GameState == GameStates.Inventory)
            {
                GameController.Instance.GameState = GameStates.Game;
            }
        }
        
    }
    void OnGameStateChanged(GameStates state)
    {
        
        pauseScreen.SetState(state == GameStates.Pause);
        gameScreen.SetState(state == GameStates.Game || state == GameStates.Inventory);
        finishScreen.SetState(state == GameStates.Finish);
        dialogScreen.SetState(state == GameStates.Dialog);
        InventoryScreen.SetState(state == GameStates.Inventory);
    }

    

    public void ShowError(string error)
    {
        //show the errors for debuging
        //SoundController.Play("error");
        gameScreen.ShowError(error);
    }
}