using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/*
 * Author: Chase Clawson
 * Date Created: 02/03/2021
 * Last Modified Date: 02/08/2021
 * Last Modified By: Chase Clawson
 * Description: Wrapper over Unity's SceneManager to allow easy transitions
 */


public static class SceneHandler
{
    //Publicly accessable enum of the loadable areas in the game, names here may be different from scene names
    public enum Areas
    {
        MainMenu,
        Tutorial
    }

    //Private list of variables to convert from the enum to a string for loading. allows us to change scene names here without having to worry about breaking other parts of the project
    private static Dictionary<Areas, string> sceneNames = new Dictionary<Areas, string>() { { Areas.MainMenu, "MainMenu" }, { Areas.Tutorial, "Tutorial"} };

    //This method will take an enum and use Unity's SceneManager to swap scenes. Any loading, unloading, and more complex scene handling will be done here if needed.
    public static void LoadArea(Areas area)
    {
        SceneManager.LoadScene(sceneNames[area]);
    }

    //This method will return to the main menu while clearing variable data to allow saving and loading without variables being carried over.
    public static void ReturnToMainMenu()
    {
        //TODO: Level variable clearing
        //TODO: Player variable clearing
        //TODO: Game control variable clearing
        SceneManager.LoadScene(sceneNames[Areas.MainMenu]);
    }
}
