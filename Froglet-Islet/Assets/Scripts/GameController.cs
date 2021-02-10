using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    protected static GameController instance;

    public UnityEvent gameStateChanged;
    public GameStates gameState;

    public static GameController Instance
    {
        get
        {
            if (instance == null || instance.gameObject == null)
            {
                instance = (GameController)FindObjectOfType(typeof(GameController));
                if (instance == null)
                {
                    Debug.LogWarning("An instance of " + typeof(GameController) + " is needed in the scene, but there is none.");
                }
            }
            return instance;
        }
    }

    public enum GameStates
    {
        Game,
        Pause,
        Inventory,
        Dialog,
        Finish
    }
}
