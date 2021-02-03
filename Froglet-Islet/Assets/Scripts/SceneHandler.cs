using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Author: Chase Clawson
 * Date Created: 02/03/2021
 * Last Modified Date: 02/03/2021
 * Last Modified By: 02/03/2021
 * Description: Wrapper over Unity's SceneManager to allow easy transitions
 */


public class SceneHandler : MonoBehaviour
{
    public enum Areas
    {
        MainMenu,
        Tutorial
    }

    public void LoadArea(Areas area)
    {
        throw new NotImplementedException();
    }

    public void ReturnToMainMenu()
    {
        throw new NotImplementedException();
    }
}
