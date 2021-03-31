using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum GameStates
{
    //Song: set layers for game states
    Game,
    Inventory,
    Pause,
    Finish,
    Dialog
}

public class GameController : Singleton<GameController>
{
    //public static UnityEvent gameStateChanged = new UnityEvent();
    public static GameStates gameState = GameStates.Game;
    public event System.Action<GameStates> onStateChanged;

    public GameStates GameState
    {
        get { return gameState; }
        set
        {
            if (value == gameState) return;
            gameState = value;
            if (onStateChanged != null) onStateChanged(gameState);
        }
    }
    void Awake()
    {
        onStateChanged += OnStateChanged;
    }

    void Start()
    {
        GameState = GameStates.Pause;
    }

    private void OnStateChanged(GameStates state)
    {
        Time.timeScale = state == GameStates.Pause || state == GameStates.Inventory ? 0 : 1;
    }
}
