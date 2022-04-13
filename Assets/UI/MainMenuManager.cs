using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    #region Public Methods

    public void LoadNextLevel()
    {
        SceneManagerAdapter.LoadNextLevel();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    

    #endregion
}
