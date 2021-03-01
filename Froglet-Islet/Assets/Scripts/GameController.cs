using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    public static UnityEvent gameStateChanged = new UnityEvent();
    public static GameStates gameState = GameStates.Game;

    public enum GameStates
    {
        Game,
        Pause,
        Inventory,
        Dialog,
        Finish
    }
}
